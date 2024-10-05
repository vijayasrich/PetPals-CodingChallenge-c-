
using PetPals.Model;
using PetPals.Dao;
using PetPals.Utility;
using System;
using System.Collections.Generic;
using System.IO;

namespace PetPals.MainModule
{
    internal class PetPalsMenu
    {
        readonly IPetDao _petDao;
        readonly IAdoptionEventDao _adoptionEventDao;
        readonly IDonationDao _donationDao;
        private int choice;
        private string petBreed;

        public PetPalsMenu()
        {
            _petDao= new PetDao();
            _adoptionEventDao= new AdoptionEventDao();
            _donationDao = new DonationDao();
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Pet Pals Management System");
                Console.WriteLine("1. Pet Management");
                Console.WriteLine("2. Adoption Event Management");
                Console.WriteLine("3. Donation Management");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int menu))
                {
                    switch (menu)
                    {
                        case 1:
                            ManagePets();
                            break;
                        case 2:
                            ManageAdoptionEvents();
                            break;
                        case 3:
                            RecordDonation();
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private PetDao petDao = new PetDao();
        private object adoptionEventData;

        private void ManagePets()
        {
            bool keepManaging = true;
            while (keepManaging)
            {
                Console.Clear();
                Console.WriteLine("Pet Management");
                Console.WriteLine("1. Add Pet");
                Console.WriteLine("2. Get Pet by ID");
                Console.WriteLine("3. Update Pet");
                Console.WriteLine("4. Delete Pet");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Pet Name: ");
                            string petName = Console.ReadLine();
                            Console.Write("Enter Pet Age: ");
                            int petAge = int.Parse(Console.ReadLine());
                            Console.Write("Enter Pet Breed: ");
                            string petBreed = Console.ReadLine();
                            Console.Write("Enter Pet Type: "); 
                            string petType = Console.ReadLine();

                            var newPet = new Pet(petName, petAge,petBreed,petType);
                            
                            _petDao.AddPet(newPet);
                            Console.WriteLine("Pet added successfully.");
                            break;

                        case 2:
                            Console.Write("Enter Pet ID: ");
                            int petId = int.Parse(Console.ReadLine());
                            var pet = _petDao.GetPetByID(petId);
                            Console.WriteLine(pet != null ? $"{pet.Name}, Age: {pet.Age},Breed: {pet.Breed}, Type:{ pet.Type}": "Pet not found.");
                            break;

                        case 3:
                            petDao.DisplayPets();

                            Console.Write("Enter Pet ID to update: ");
                            int petIDToUpdate = int.Parse(Console.ReadLine());

                            // Call the method to update the pet
                            var existingPet = _petDao.GetPetByID(petIDToUpdate);
                            if (existingPet != null)
                            {
                                // Gather updated pet details
                                Console.Write("Enter new name (leave empty to keep unchanged): ");
                                string newName = Console.ReadLine();
                                Console.Write("Enter new age (leave empty to keep unchanged): ");
                                string newAgeInput = Console.ReadLine();
                                Console.Write("Enter new breed (leave empty to keep unchanged): ");
                                string newBreed = Console.ReadLine();

                                // Update the pet with new details
                                existingPet.Name = string.IsNullOrWhiteSpace(newName) ? existingPet.Name : newName;
                                existingPet.Age = string.IsNullOrWhiteSpace(newAgeInput) ? existingPet.Age : int.Parse(newAgeInput);
                                existingPet.Breed = string.IsNullOrWhiteSpace(newBreed) ? existingPet.Breed : newBreed;

                                _petDao.UpdatePet(existingPet);
                                Console.WriteLine("Pet updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Pet not found.");
                            }
                            break;
                        
                        case 4:
                            petDao.DisplayPets();
                            Console.Write("Enter Pet ID to delete: ");
                            int petIdToDelete = int.Parse(Console.ReadLine());

                            var petToDelete = petDao.GetPetByID(petIdToDelete);
                            if (petToDelete != null)
                            {
                                petDao.DeletePet(petIdToDelete);
                                Console.WriteLine("Pet deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Pet not found.");
                            }
                            break;
                       

                        case 5:
                            keepManaging = false; 
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}. Please enter the correct format.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                // Pause before clearing the screen and showing the menu again
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Pause until the user presses any key
            }
        }

        private void ManageAdoptionEvents()
        {
            bool keepManaging = true;
            while (keepManaging)
            {
                Console.Clear();
                Console.WriteLine("Adoption Event Management");
                Console.WriteLine("1. Add Adoption Event");
                Console.WriteLine("2. Get Adoption Event by ID");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Select an option: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Event Name: ");
                            string eventName = Console.ReadLine();
                            Console.Write("Enter Event Date (yyyy-MM-dd): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime eventDate) ||
                                eventDate < new DateTime(1753, 1, 1) ||
                                eventDate > new DateTime(9999, 12, 31))
                            {
                                Console.WriteLine("Invalid date. Please enter a date between 1/1/1753 and 12/31/9999.");
                                continue; 
                            }

                            
                            ;
                            Console.Write("Enter Location: ");
                            string location = Console.ReadLine();

                            var newEvent = new AdoptionEvent
                            {
                                EventName = eventName,
                                EventDate = eventDate,
                                Location = location
                            };

                            _adoptionEventDao.AddAdoptionEvent(newEvent);
                            Console.WriteLine("Adoption Event added successfully.");
                            break;

                        case 2:
                            Console.Write("Enter Event ID: ");
                            int eventId = int.Parse(Console.ReadLine());
                            var adoptionEvent = _adoptionEventDao.GetAdoptionEventByID(eventId);
                            Console.WriteLine(adoptionEvent != null ? $"{adoptionEvent.EventName}, Date: {adoptionEvent.EventDate}, Location: {adoptionEvent.Location}" : "Event not found.");
                            break;

                        case 3:
                            keepManaging = false; // Exit the loop and return to the main menu
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}. Please enter the correct format.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                // Pause before clearing the screen and showing the menu again
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Pause until the user presses any key
            }
        }

        private void RecordDonation()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Donation Management");
                Console.Write("Enter Donor Name: ");
                string donorName = Console.ReadLine();
                Console.Write("Enter Donation Amount: ");
                decimal donationAmount = decimal.Parse(Console.ReadLine());

                if (donationAmount < 40)
                {
                    Console.WriteLine("Donation amount must be at least 40.");
                }
                else
                {
                    var donationDate = DateTime.Now; // Current date
                    var cashDonation = new CashDonation(donorName, donationAmount, donationDate);

                    _donationDao.RecordDonation(cashDonation);
                    Console.WriteLine("Donation recorded successfully.");
                }
               
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}. Please enter a valid donation amount.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Donation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(); 
        }
    }
}

