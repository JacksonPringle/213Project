namespace TheDogApp
{
    public class Shelter
    {private static string adoptionFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DogAdoptionApplications.txt");

    public static void AddApplication(string adopterName, string dogName, string status)
    {
        if (string.IsNullOrWhiteSpace(adopterName) || string.IsNullOrWhiteSpace(dogName) || string.IsNullOrWhiteSpace(status))
        {
            Console.WriteLine("Error: All fields are required.");
            return;
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(adoptionFilePath, true))
            {
                writer.WriteLine($"{adopterName},{dogName},{status}");
            }
            Console.WriteLine("Adoption application added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding application: {ex.Message}");
        }
    }

    public static void ViewApplications()
    {
        if (!File.Exists(adoptionFilePath))
        {
            Console.WriteLine("No applications found.");
            return;
        }

        try
        {
            string[] applications = File.ReadAllLines(adoptionFilePath);
            Console.WriteLine("Adoption Applications:");
            foreach (string application in applications)
            {
                string[] fields = application.Split(',');
                Console.WriteLine($"Adopter: {fields[0]}, Dog: {fields[1]}, Status: {fields[2]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading applications: {ex.Message}");
        }
    }

    public static void UpdateApplicationStatus(string adopterName, string newStatus)
    {
        if (!File.Exists(adoptionFilePath))
        {
            Console.WriteLine("No applications to update.");
            return;
        }

        List<string> updatedApplications = new List<string>();
        bool applicationFound = false;

        try
        {
            foreach (string application in File.ReadAllLines(adoptionFilePath))
            {
                string[] fields = application.Split(',');
                if (fields[0].Equals(adopterName, StringComparison.OrdinalIgnoreCase))
                {
                    updatedApplications.Add($"{fields[0]},{fields[1]},{newStatus}");
                    applicationFound = true;
                }
                else
                {
                    updatedApplications.Add(application);
                }
            }

            if (applicationFound)
            {
                File.WriteAllLines(adoptionFilePath, updatedApplications);
                Console.WriteLine("Application status updated successfully.");
            }
            else
            {
                Console.WriteLine("Application not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating application: {ex.Message}");
        }
    }

    public static void DeleteApplication(string adopterName)
    {
        if (!File.Exists(adoptionFilePath))
        {
            Console.WriteLine("No applications to delete.");
            return;
        }

        List<string> remainingApplications = new List<string>();
        bool applicationDeleted = false;

        try
        {
            foreach (string application in File.ReadAllLines(adoptionFilePath))
            {
                string[] fields = application.Split(',');
                if (!fields[0].Equals(adopterName, StringComparison.OrdinalIgnoreCase))
                {
                    remainingApplications.Add(application);
                }
                else
                {
                    applicationDeleted = true;
                }
            }

            if (applicationDeleted)
            {
                File.WriteAllLines(adoptionFilePath, remainingApplications);
                Console.WriteLine("Application deleted successfully.");
            }
            else
            {
                Console.WriteLine("Application not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting application: {ex.Message}");
        }
    }

    static void Main(string[] args)
    {
        // Example usage
        AddApplication("Alice Smith", "Buddy", "Pending");
        AddApplication("John Doe", "Max", "Approved");
        ViewApplications();
        UpdateApplicationStatus("Alice Smith", "Approved");
        ViewApplications();
        DeleteApplication("John Doe");
        ViewApplications();
    }
    }
}
