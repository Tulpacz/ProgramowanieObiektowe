using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerwisRowerowy.encje;
using SerwisRowerowy;

namespace SerwisRowerowy
{
    public class BikeShopApp
    {
        private readonly DatabaseManager _dbManager;

        public BikeShopApp(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Program do obsługi serwisu rowerowego");
                Console.WriteLine("============================");
                Console.WriteLine("1. Wyświetl klientów");
                Console.WriteLine("2. Dodaj klienta");
                Console.WriteLine("3. Zmień dane klienta");
                Console.WriteLine("4. Usuń klienta");
                Console.WriteLine("5. Menu części");
                Console.WriteLine("6. Menu dostawców");
                Console.WriteLine("7. Menu pracowników");
                Console.WriteLine("8. Menu rowerów");
                Console.WriteLine("9. Menu zleceń");
                Console.WriteLine("10. Menu dostawców");
                Console.WriteLine("11. Menu usług");
                Console.WriteLine("12. Wyjście");
                Console.Write("Wybierz opcję: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewClients();
                        break;
                    case "2":
                        AddClient();
                        break;
                    case "3":
                        UpdateClient();
                        break;
                    case "4":
                        DeleteClient();
                        break;
                    case "5":
                        ManageParts();
                        break;
                    case "6":
                        ManageSuppliers();
                        break;
                    case "7":
                        ManageEmployees();
                        break;
                    case "8":
                        ManageBikes();
                        break;
                    case "9":
                        ManageOrders();
                        break;
                    case "10":
                        ManageSuppliers();
                        break;
                    case "11":
                        ManageServices();
                        break;


                    case "12":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór, naciśnij Enter aby kontynuować...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ViewClients()
        {
            Console.Clear();
            Console.WriteLine("Lista klientów");
            Console.WriteLine("================");
            List<Klient> clients = _dbManager.GetClients();

            foreach (var client in clients)
            {
                Console.WriteLine($"ID: {client.ID_klienta}, Name: {client.Imie} {client.Nazwisko}, Phone: {client.Nr_telefonu}, Email: {client.Email}");
            }

            Console.WriteLine("\nNaciśnij Enter aby wrócić do menu...");
            Console.ReadLine();
        }

        private void AddClient()
        {
            Console.Clear();
            Console.WriteLine("Dodaj klienta");
            Console.WriteLine("================");

            Klient client = new Klient();

            Console.Write("Imię: ");
            client.Imie = Console.ReadLine();

            Console.Write("Nazwisko: ");
            client.Nazwisko = Console.ReadLine();

            Console.Write("Nr telefonu: ");
            client.Nr_telefonu = Console.ReadLine();

            Console.Write("Email: ");
            client.Email = Console.ReadLine();

            _dbManager.AddClient(client);
            Console.WriteLine("Klient został dodany, naciśnij Enter aby wrócić do menu...");
            Console.ReadLine();
        }

        private void UpdateClient()
        {
            Console.Clear();
            Console.WriteLine("Zmień dane klienta");
            Console.WriteLine("================");

            Console.Write("Podaj ID klienta: ");
            int clientId = int.Parse(Console.ReadLine());

            Klient client = new Klient { ID_klienta = clientId };

            Console.Write("Nowe imię: ");
            client.Imie = Console.ReadLine();

            Console.Write("Nowe nazwisko: ");
            client.Nazwisko = Console.ReadLine();

            Console.Write("Nowy nr telefonu: ");
            client.Nr_telefonu = Console.ReadLine();

            Console.Write("Nowy Email: ");
            client.Email = Console.ReadLine();

            _dbManager.UpdateClient(client);
            Console.WriteLine("Dane zostały zmienione, naciśnij Enter aby wrócić do menu...");
            Console.ReadLine();
        }

        private void DeleteClient()
        {
            Console.Clear();
            Console.WriteLine("Usuń klienta");
            Console.WriteLine("================");

            Console.Write("Podaj ID klienta do usunięcia: ");
            int clientId = int.Parse(Console.ReadLine());

            _dbManager.DeleteClient(clientId);
            Console.WriteLine("Klient usunięty, naciśnij Enter aby wrócić do menu...");
            Console.ReadLine();
        }
        private void ManageParts()
        {
            Console.Clear();
            Console.WriteLine("Menu części");
            Console.WriteLine("============");
            Console.WriteLine("1. Wyświetl części");
            Console.WriteLine("2. Dodaj część");
            Console.WriteLine("3. Powrót");
            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewParts();
                    break;
                case "2":
                    AddPart();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, naciśnij Enter aby kontynuować...");
                    Console.ReadLine();
                    break;
            }
        }

        private void ViewParts()
        {
            Console.Clear();
            var parts = _dbManager.GetParts();
            foreach (var part in parts)
            {
                Console.WriteLine($"Kod: {part.KOD_czesci}, Typ: {part.Rodzaj}, ID Dostawcy: {part.Dostawca}");
            }
            Console.WriteLine("\nNaciśnij Enter aby kontynuować..");
            Console.ReadLine();
        }

        private void AddPart()
        {
            Console.Clear();
            Console.WriteLine("Dodaj część");
            Console.WriteLine("============");
            Console.Write("Kod: ");
            var kod = Console.ReadLine();
            Console.Write("Typ: ");
            var rodzaj = Console.ReadLine();
            Console.Write("ID Dostawcy: ");
            var dostawca = int.Parse(Console.ReadLine());

            Czesc czesc = new Czesc { KOD_czesci = kod, Rodzaj = rodzaj, Dostawca = dostawca };
            _dbManager.AddPart(czesc);

            Console.WriteLine("Część dodana, naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }
        private void ManageEmployees()
        {
            Console.Clear();
            Console.WriteLine("Menu pracowników");
            Console.WriteLine("================");
            Console.WriteLine("1. Wyświetl pracowników");
            Console.WriteLine("2. Dodaj pracownika");
            Console.WriteLine("3. Usuń pracownika");
            Console.WriteLine("4. Powrót");
            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewEmployees();
                    break;
                case "2":
                    AddEmployee();
                    break;
                case "3":
                    DeleteEmployee();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, naciśnij Enter aby kontynuować...");
                    Console.ReadLine();
                    break;
            }
        }
        private void ViewEmployees()
        {
            Console.Clear();
            Console.WriteLine("Pracownicy:");
            var employees = _dbManager.GetEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.ID_pracownika}, Imię: {employee.Imie} {employee.Nazwisko}, Stanowisko: {employee.Stanowisko_zawodowe}");
            }
            Console.WriteLine("\nNaciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }
        private void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("Dodaj pracownika");
            Console.Write("Imię: ");
            var firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            var lastName = Console.ReadLine();
            Console.Write("Stanowisko: ");
            var jobPosition = Console.ReadLine();

            var employee = new Pracownik { Imie = firstName, Nazwisko = lastName, Stanowisko_zawodowe = jobPosition };
            _dbManager.AddEmployee(employee);
            Console.WriteLine("Pracownik dodany, naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }
        private void DeleteEmployee()
        {
            Console.Clear();
            Console.WriteLine("Usuń pracownika");
            Console.Write("Podaj ID pracownika do usunięcia: ");
            int employeeId = int.Parse(Console.ReadLine());

            _dbManager.DeleteEmployee(employeeId);
            Console.WriteLine("Pracownik usunięty, naciśnij Enter aby kontynuować......");
            Console.ReadLine();
        }
        private void ManageBikes()
        {
            Console.Clear();
            Console.WriteLine("Menu rowerów");
            Console.WriteLine("============");
            Console.WriteLine("1. Wyświetl rowery");
            Console.WriteLine("2. Dodaj rower");
            Console.WriteLine("3. Usuń rower");
            Console.WriteLine("4. Powrót");
            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewBikes();
                    break;
                case "2":
                    AddBike();
                    break;
                case "3":
                    DeleteBike();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, naciśnij Enter aby kontynuować...");
                    Console.ReadLine();
                    break;
            }
        }
        private void ViewBikes()
        {
            Console.Clear();
            Console.WriteLine("Rowery:");
            var bikes = _dbManager.GetBikes();
            foreach (var bike in bikes)
            {
                Console.WriteLine($"ID: {bike.ID}, Marka: {bike.Marka}, Model: {bike.Model}, Kolor: {bike.Kolor}, Rok produkcji: {bike.Rok_produkcji}, ID właściciela: {bike.Wlasciciel}");
            }
            Console.WriteLine("\nNaciśnij Enter aby kontynuować");
            Console.ReadLine();
        }
        private void AddBike()
        {
            Console.Clear();
            Console.WriteLine("Dodaj rower");
            Console.Write("Marka: ");
            var brand = Console.ReadLine();
            Console.Write("Model: ");
            var model = Console.ReadLine();
            Console.Write("Kolor: ");
            var color = Console.ReadLine();
            Console.Write("Rok produkcji: ");
            int productionYear = int.Parse(Console.ReadLine());
            Console.Write("ID właściciela: ");
            int ownerId = int.Parse(Console.ReadLine());

            var rower = new Rower
            {
                Marka = brand,
                Model = model,
                Kolor = color,
                Rok_produkcji = productionYear,
                Wlasciciel = ownerId
            };
            _dbManager.AddBike(rower);
            Console.WriteLine("Rower dodany, naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }
        private void DeleteBike()
        {
            Console.Clear();
            Console.WriteLine("Usuń rower");
            Console.Write("Podaj ID roweru do usunięcia: ");
            int bikeId = int.Parse(Console.ReadLine());

            _dbManager.DeleteBike(bikeId);
            Console.WriteLine("Rower usunięty, naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }
        private void ManageServices()
        {
            Console.Clear();
            Console.WriteLine("Menu usług");
            Console.WriteLine("===============");
            Console.WriteLine("1. Wyświetl usługi");
            Console.WriteLine("2. Dodaj usługę");
            Console.WriteLine("3. Usuń usługę");
            Console.WriteLine("4. Powrót");
            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewServices();
                    break;
                case "2":
                    AddService();
                    break;
                case "3":
                    DeleteService();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, naciśnij Enter aby kontynuować...");
                    Console.ReadLine();
                    break;
            }
        }
        private void ViewServices()
        {
            Console.Clear();
            Console.WriteLine("Usługi:");
            var services = _dbManager.GetServices();
            foreach (var service in services)
            {
                Console.WriteLine($"ID: {service.ID_uslugi}, Nazwa usługi: {service.Nazwa_uslugi}, Cena: {service.Cena}");
            }
            Console.WriteLine("\nNaciśnij enter aby kontynuować...");
            Console.ReadLine();
        }
        private void AddService()
        {
            Console.Clear();
            Console.WriteLine("Dodaj usługę");
            Console.Write("Nazwa usługi: ");
            var name = Console.ReadLine();
            Console.Write("Cena: ");
            decimal price = decimal.Parse(Console.ReadLine());

            var service = new Usluga { Nazwa_uslugi = name, Cena = price };
            _dbManager.AddService(service);
            Console.WriteLine("Usługa dodana, naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }
        private void DeleteService()
        {
            Console.Clear();
            Console.WriteLine("Usuń usługę");
            Console.Write("Podaj ID usługi do usunięcia: ");
            int serviceId = int.Parse(Console.ReadLine());

            _dbManager.DeleteService(serviceId);
            Console.WriteLine("Usługa usunięta, naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }

        private void ManageOrders()
        {
            Console.Clear();
            Console.WriteLine("Menu zleceń");
            Console.WriteLine("=============");
            Console.WriteLine("1. Wyświetl zlecenia");
            Console.WriteLine("2. Dodaj zlecenie");
            Console.WriteLine("3. Usuń zlecenie");
            Console.WriteLine("4. Dodaj część do zlecenia");
            Console.WriteLine("5. Dodaj usługę do zlecenia");
            Console.WriteLine("6. Wyświetl szczegóły zlecenia");
            Console.WriteLine("7. Usuń część ze zlecenia");
            Console.WriteLine("8. Usuń usługę ze zlecenia");
            Console.WriteLine("9. Powrót");
            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewOrders();
                    break;
                case "2":
                    AddOrder();
                    break;
                case "3":
                    DeleteOrder();
                    break;
                case "4":
                    AddPartToOrder();
                    break;
                case "5":
                    AddServiceToOrder();
                    break;
                case "6":
                    ViewOrderDetails();
                    break;
                case "7":
                    RemovePartFromOrder();
                    break;
                case "8":
                    RemoveServiceFromOrder();
                    break;

                case "9":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, naciśnij Enter aby kontynuować...");
                    Console.ReadLine();
                    break;
            }
        }

        private void ViewOrders()
        {
            Console.Clear();
            Console.WriteLine("Zlecenia:");
            var orders = _dbManager.GetOrders();
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.ID_zlecenia}, Data przyjęcia: {order.Data_przyjecia}, Status: {order.Status}, Opis problemu: {order.Opis_problemu}, Pracownik: {order.Pracownik}, Rower: {order.Rower}");
            }
            Console.WriteLine("\nNaciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }
        private void AddOrder()
        {
            Console.Clear();
            Console.WriteLine("Dodaj zlecenie");
            Console.WriteLine("=============");

            try
            {
                Console.Write("Data przyjęcia (rrrr-mm-dd): ");
                DateTime dateReceived = DateTime.Parse(Console.ReadLine());

                Console.Write("Status: ");
                var status = Console.ReadLine();

                Console.Write("Opis problemu: ");
                var problemDescription = Console.ReadLine();

                Console.Write("ID pracownika: ");
                int employeeId = int.Parse(Console.ReadLine());

                Console.Write("ID roweru: ");
                int bikeId = int.Parse(Console.ReadLine());

                var order = new Zlecenie
                {
                    Data_przyjecia = dateReceived,
                    Status = status,
                    Opis_problemu = problemDescription,
                    Pracownik = employeeId,
                    Rower = bikeId
                };

                _dbManager.AddOrder(order);
                Console.WriteLine("Zlecenie zostało dodane!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd: Wprowadzono nieprawidłowe dane. Spróbuj ponownie.");
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd: Wprowadzono nieprawidłowe ID roweru lub pracownika.");
            }

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();
        }
        private void DeleteOrder()
        {
            Console.Clear();
            Console.WriteLine("Usuń zlecenie");
            Console.WriteLine("============");
            Console.Write("Podaj ID zlecenia do usunięcia: ");

            if (int.TryParse(Console.ReadLine(), out int orderId))
            {
                try
                {
                    _dbManager.DeleteOrder(orderId);
                    Console.WriteLine("Zlecenie usunięte, naciśnij enter aby kontynuować...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowe ID, naciśnij Enter aby kontynuować...");
            }

            Console.ReadLine();
        }



        private void ManageSuppliers()
        {
            Console.Clear();
            Console.WriteLine("Menu dostawców");
            Console.WriteLine("================");
            Console.WriteLine("1. Wyświetl dostawców");
            Console.WriteLine("2. Dodaj dostawcę");
            Console.WriteLine("3. Powrót");
            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewSuppliers();
                    break;
                case "2":
                    AddSupplier();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, naciśnij Enter aby kontynuować...");
                    Console.ReadLine();
                    break;
            }
        }

        private void ViewSuppliers()
        {
            Console.Clear();
            var suppliers = _dbManager.GetSuppliers();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"ID: {supplier.ID_dostawcy}, Nazwa dostawcy: {supplier.Nazwa_dostawcy}, Nr telefonu: {supplier.Nr_telefonu}, Email: {supplier.Email}");
            }
            Console.WriteLine("\nNaciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }

        private void AddSupplier()
        {
            Console.Clear();
            Console.WriteLine("Dodaj dostawcę");
            Console.WriteLine("================");
            Console.Write("Nazwa dostawcy: ");
            var name = Console.ReadLine();
            Console.Write("Nr telefonu: ");
            var phone = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();

            var supplier = new Dostawca { Nazwa_dostawcy = name, Nr_telefonu = phone, Email = email };
            _dbManager.AddSupplier(supplier);

            Console.WriteLine("Dostawca dodany, naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }
        private void AddPartToOrder()
        {
            Console.Clear();
            Console.WriteLine("Dodaj część do zlecenia");
            Console.WriteLine("=================");

            try
            {
                Console.Write("Podaj ID zlecenia: ");
                int orderId = int.Parse(Console.ReadLine());

                Console.Write("Podaj ID części: ");
                int partId = int.Parse(Console.ReadLine());

                _dbManager.AddPartToOrder(orderId, partId);
                Console.WriteLine("Dodano część do zamówienia!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd. Podaj poprawne numery ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Niespodziewany błąd: {ex.Message}");
            }

            Console.WriteLine("\nNaciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }

        private void AddServiceToOrder()
        {
            Console.Clear();
            Console.WriteLine("Dodaj usługę do zlecenia");
            Console.WriteLine("====================");
            Console.Write("Podaj ID zlecenia: ");
            int orderId = int.Parse(Console.ReadLine());
            Console.Write("Podaj ID usługi: ");
            int serviceId = int.Parse(Console.ReadLine());

            _dbManager.AddServiceToOrder(orderId, serviceId);
            Console.WriteLine("Usługa dodana do zlecenia! Naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }
        /*private void AddBikeToOrder()
        {
            Console.Clear();
            Console.WriteLine("Add Bike to Order");
            Console.WriteLine("=================");
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());
            Console.Write("Enter Bike ID: ");
            int bikeId = int.Parse(Console.ReadLine());

            _dbManager.AddBikeToOrder(orderId, bikeId);
            Console.WriteLine("Bike added to order successfully! Naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }*/
        private void RemovePartFromOrder()
        {
            Console.Clear();
            Console.WriteLine("Usuń część ze zlecenia");
            Console.WriteLine("=======================");
            Console.Write("Podaj ID zlecenia: ");
            int orderId = int.Parse(Console.ReadLine());
            Console.Write("Podaj ID części: ");
            int partId = int.Parse(Console.ReadLine());

            _dbManager.RemovePartFromOrder(orderId, partId);
            Console.WriteLine("Usunięto część ze zlecenia! Naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }

        private void RemoveServiceFromOrder()
        {
            Console.Clear();
            Console.WriteLine("Usuń usługę ze zlecenia");
            Console.WriteLine("==========================");
            Console.Write("Podaj ID zlecenia: ");
            int orderId = int.Parse(Console.ReadLine());
            Console.Write("Podaj ID usługi: ");
            int serviceId = int.Parse(Console.ReadLine());

            _dbManager.RemoveServiceFromOrder(orderId, serviceId);
            Console.WriteLine("Usunięto usługę ze zlecenia! Naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }

        /*private void RemoveBikeFromOrder()
        {
            Console.Clear();
            Console.WriteLine("Remove Bike from Order");
            Console.WriteLine("=======================");
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());
            Console.Write("Enter Bike ID: ");
            int bikeId = int.Parse(Console.ReadLine());

            _dbManager.RemoveBikeFromOrder(orderId, bikeId);
            Console.WriteLine("Bike removed from order successfully! Naciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }*/
        private void ViewOrderDetails()
        {
            Console.Clear();
            Console.WriteLine("Wyświetl szczegóły zlecenia");
            Console.WriteLine("==================");
            Console.Write("Podaj ID zlecenia: ");
            int orderId = int.Parse(Console.ReadLine());

            Console.WriteLine("\nCzęści:");
            var parts = _dbManager.GetPartsForOrder(orderId);
            foreach (var part in parts)
            {
                Console.WriteLine($"- {part.KOD_czesci}, {part.Rodzaj}");
            }

            Console.WriteLine("\nUsługi:");
            var services = _dbManager.GetServicesForOrder(orderId);
            foreach (var service in services)
            {
                Console.WriteLine($"- {service.Nazwa_uslugi}, Cena: {service.Cena:C}");
            }

            Console.WriteLine("\nBikes:");
            var bike = _dbManager.GetBikeForOrder(orderId);
            Console.WriteLine($"- {bike.Marka} {bike.Model}, Kolor: {bike.Kolor}, Rok produkcji: {bike.Rok_produkcji}");

            Console.WriteLine("\nNaciśnij Enter aby kontynuować...");
            Console.ReadLine();
        }

    }
}

