using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerwisRowerowy.encje;

using Microsoft.Data.SqlClient;
namespace SerwisRowerowy
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Klient> GetClients()
        {
            var clients = new List<Klient>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    Console.WriteLine("przedopen");
                    connection.Open();
                    Console.WriteLine("poopen");

                    string query = "SELECT * FROM Klienci";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Klient
                            {
                                ID_klienta = Convert.ToInt32(reader["ID_klienta"]),
                                Imie = reader["Imie"].ToString(),
                                Nazwisko = reader["Nazwisko"].ToString(),
                                Nr_telefonu = reader["Nr_telefonu"].ToString(),
                                Email = reader["Email"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching clients: " + ex.Message);
            }

            return clients;
        }

        public void AddClient(Klient client)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Klienci (Imie, Nazwisko, Nr_telefonu, Email) VALUES (@FirstName, @LastName, @PhoneNumber, @Email)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FirstName", client.Imie);
                command.Parameters.AddWithValue("@LastName", client.Nazwisko);
                command.Parameters.AddWithValue("@PhoneNumber", client.Nr_telefonu);
                command.Parameters.AddWithValue("@Email", client.Email);
                //command.Parameters.AddWithValue("@ID", client.ID_klienta);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateClient(Klient client)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Klienci SET Imie = @FirstName, Nazwisko = @LastName, Nr_telefonu = @PhoneNumber, Email = @Email WHERE ID_klienta = @ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FirstName", client.Imie);
                command.Parameters.AddWithValue("@LastName", client.Nazwisko);
                command.Parameters.AddWithValue("@PhoneNumber", client.Nr_telefonu);
                command.Parameters.AddWithValue("@Email", client.Email);
                command.Parameters.AddWithValue("@ID", client.ID_klienta);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteClient(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Klienci WHERE ID_klienta = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", clientId);

                command.ExecuteNonQuery();
            }
        }
        public List<Czesc> GetParts()
        {
            var parts = new List<Czesc>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Czesci";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        parts.Add(new Czesc
                        {
                            KOD_czesci = reader["KOD_czesci"].ToString(),
                            Rodzaj = reader["Rodzaj"].ToString(),
                            Dostawca = Convert.ToInt32(reader["Dostawca"])
                        });
                    }
                }
            }
            return parts;
        }

        public void AddPart(Czesc czesc)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Czesci (KOD_czesci, Rodzaj, Dostawca) VALUES (@Code, @Type, @Supplier)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Code", czesc.KOD_czesci);
                command.Parameters.AddWithValue("@Type", czesc.Rodzaj);
                command.Parameters.AddWithValue("@Supplier", czesc.Dostawca);
                command.ExecuteNonQuery();
            }
        }
        public List<Pracownik> GetEmployees()
        {
            var employees = new List<Pracownik>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Pracownicy";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Pracownik
                        {
                            ID_pracownika = Convert.ToInt32(reader["ID_pracownika"]),
                            Imie = reader["Imie"].ToString(),
                            Nazwisko = reader["Nazwisko"].ToString(),
                            Stanowisko_zawodowe = reader["Stanowisko_zawodowe"].ToString()
                        });
                    }
                }
            }
            return employees;
        }
        public void AddEmployee(Pracownik employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Pracownicy (Imie, Nazwisko, Stanowisko_zawodowe) VALUES (@FirstName, @LastName, @JobPosition)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", employee.Imie);
                command.Parameters.AddWithValue("@LastName", employee.Nazwisko);
                command.Parameters.AddWithValue("@JobPosition", employee.Stanowisko_zawodowe);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Pracownicy WHERE ID_pracownika = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeId);
                command.ExecuteNonQuery();
            }
        }
        public List<Zlecenie> GetOrders()
        {
            var orders = new List<Zlecenie>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Zlecenia";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Zlecenie
                        {
                            ID_zlecenia = Convert.ToInt32(reader["ID_zlecenia"]),
                            Data_przyjecia = Convert.ToDateTime(reader["Data_przyjecia"]),
                            Status = reader["Status"].ToString(),
                            Opis_problemu = reader["Opis_problemu"].ToString(),
                            Pracownik = Convert.ToInt32(reader["Pracownik"]),
                            Rower = Convert.ToInt32(reader["Rower"])
                        });
                    }
                }
            }
            return orders;
        }
        public void AddOrder(Zlecenie order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Sprawdzanie, czy rower i pracownik istnieją
                string checkQuery = @"
            SELECT 
                (SELECT COUNT(*) FROM Rowery WHERE ID_roweru = @BikeID) AS BikeExists, 
                (SELECT COUNT(*) FROM Pracownicy WHERE ID_pracownika = @EmployeeID) AS EmployeeExists";

                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@BikeID", order.Rower);
                checkCommand.Parameters.AddWithValue("@EmployeeID", order.Pracownik);

                using (SqlDataReader reader = checkCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader.GetInt32(0) == 0 || reader.GetInt32(1) == 0)
                        {
                            throw new Exception("Błąd: Wprowadzono nieprawidłowe ID roweru lub pracownika.");
                        }
                    }
                }

                // Dodawanie zlecenia
                string query = "INSERT INTO Zlecenia (Data_przyjecia, Status, Opis_problemu, Pracownik, Rower) " +
                               "VALUES (@DateReceived, @Status, @ProblemDescription, @EmployeeID, @BikeID)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DateReceived", order.Data_przyjecia);
                command.Parameters.AddWithValue("@Status", order.Status);
                command.Parameters.AddWithValue("@ProblemDescription", order.Opis_problemu);
                command.Parameters.AddWithValue("@EmployeeID", order.Pracownik);
                command.Parameters.AddWithValue("@BikeID", order.Rower);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Zlecenia WHERE ID_zlecenia = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);
                command.ExecuteNonQuery();
            }
        }
        public List<Rower> GetBikes()
        {
            var bikes = new List<Rower>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Rowery";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bikes.Add(new Rower
                        {
                            ID = Convert.ToInt32(reader["ID_roweru"]),
                            Marka = reader["Marka"].ToString(),
                            Model = reader["Model"].ToString(),
                            Kolor = reader["Kolor"].ToString(),
                            Rok_produkcji = Convert.ToInt32(reader["Rok_produkcji"]),
                            Wlasciciel = Convert.ToInt32(reader["Wlasciciel"])
                        });
                    }
                }
            }
            return bikes;
        }
        public void AddBike(Rower rower)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Rowery (Marka, Model, Kolor, Rok_produkcji, Wlasciciel) VALUES (@Brand, @Model, @Color, @ProductionYear, @OwnerID)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Brand", rower.Marka);
                command.Parameters.AddWithValue("@Model", rower.Model);
                command.Parameters.AddWithValue("@Color", rower.Kolor);
                command.Parameters.AddWithValue("@ProductionYear", rower.Rok_produkcji);
                command.Parameters.AddWithValue("@OwnerID", rower.Wlasciciel);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteBike(int bikeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Rowery WHERE ID_roweru = @BikeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BikeID", bikeId);
                command.ExecuteNonQuery();
            }
        }
        public List<Usluga> GetServices()
        {
            var services = new List<Usluga>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Uslugi";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        services.Add(new Usluga
                        {
                            ID_uslugi = Convert.ToInt32(reader["ID_uslugi"]),
                            Nazwa_uslugi = reader["Nazwa_uslugi"].ToString(),
                            Cena = Convert.ToDecimal(reader["Cena"])
                        });
                    }
                }
            }
            return services;
        }
        public void AddService(Usluga service)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Uslugi (Nazwa_uslugi, Cena) VALUES (@Name, @Price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", service.Nazwa_uslugi);
                command.Parameters.AddWithValue("@Price", service.Cena);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteService(int serviceId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Uslugi WHERE ID_uslugi = @ServiceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceID", serviceId);
                command.ExecuteNonQuery();
            }
        }



        public List<Dostawca> GetSuppliers()
        {
            var suppliers = new List<Dostawca>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Dostawcy";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        suppliers.Add(new Dostawca
                        {
                            ID_dostawcy = Convert.ToInt32(reader["ID_dostawcy"]),
                            Nazwa_dostawcy = reader["Nazwa_dostawcy"].ToString(),
                            Nr_telefonu = reader["Nr_telefonu"].ToString(),
                            Email = reader["Email"].ToString()
                        });
                    }
                }
            }
            return suppliers;
        }

        public void AddSupplier(Dostawca supplier)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Dostawcy (Nazwa_dostawcy, Nr_telefonu, Email) VALUES (@Name, @Phone, @Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", supplier.Nazwa_dostawcy);
                command.Parameters.AddWithValue("@Phone", supplier.Nr_telefonu);
                command.Parameters.AddWithValue("@Email", supplier.Email);
                command.ExecuteNonQuery();
            }
        }
        public void AddPartToOrder(int orderId, int partId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // sprawdzenie czy zlecenie istnieje
                string checkOrderQuery = "SELECT COUNT(*) FROM Zlecenia WHERE ID_zlecenia = @OrderId";
                SqlCommand checkOrderCommand = new SqlCommand(checkOrderQuery, connection);
                checkOrderCommand.Parameters.AddWithValue("@OrderId", orderId);
                int orderExists = (int)checkOrderCommand.ExecuteScalar();

                if (orderExists == 0)
                {
                    throw new ArgumentException($"Order with ID {orderId} does not exist.");
                }

                // sprawdzenie czy część istnieje
                string checkPartQuery = "SELECT COUNT(*) FROM Czesci WHERE ID_czesci = @PartId";
                SqlCommand checkPartCommand = new SqlCommand(checkPartQuery, connection);
                checkPartCommand.Parameters.AddWithValue("@PartId", partId);
                int partExists = (int)checkPartCommand.ExecuteScalar();

                if (partExists == 0)
                {
                    throw new ArgumentException($"Part with ID {partId} does not exist.");
                }

                string query = "INSERT INTO Czesci-Zlecenia (Zlecenie_ID, Czesc_ID) VALUES (@OrderId, @PartId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@PartId", partId);
                command.ExecuteNonQuery();
            }
        }

        public void AddServiceToOrder(int orderId, int serviceId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [Uslugi-Zlecenia] (ID_zlecenia, ID_uslugi) VALUES (@OrderId, @ServiceId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@ServiceId", serviceId);
                command.ExecuteNonQuery();
            }
        }

        public List<Czesc> GetPartsForOrder(int orderId)
        {
            var parts = new List<Czesc>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT Czesci.* FROM Czesci
                         INNER JOIN [Czesci-Zlecenia] ON Czesci.ID_czesci = [Czesci-Zlecenia].ID_czesci
                         WHERE [Czesci-Zlecenia].ID_zlecenia = @OrderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        parts.Add(new Czesc
                        {
                            KOD_czesci = reader["KOD_czesci"].ToString(),
                            Rodzaj = reader["Rodzaj"].ToString(),
                            Dostawca = Convert.ToInt32(reader["Dostawca"])
                        });
                    }
                }
            }
            return parts;
        }
        public void RemovePartFromOrder(int orderId, int partId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM [Czesci-Zlecenia] WHERE ID_zlecenia = @OrderId AND ID_czesci = @PartId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@PartId", partId);
                command.ExecuteNonQuery();
            }
        }
        public void RemoveServiceFromOrder(int orderId, int serviceId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM [Uslugi-Zlecenia] WHERE ID_zlecenia = @OrderId AND ID_uslugi = @ServiceId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.Parameters.AddWithValue("@ServiceId", serviceId);
                command.ExecuteNonQuery();
            }
        }

        public List<Usluga> GetServicesForOrder(int orderId)
        {
            var services = new List<Usluga>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT Uslugi.* FROM Uslugi
                         INNER JOIN [Uslugi-Zlecenia] ON [Uslugi].ID_uslugi = [Uslugi-Zlecenia].ID_uslugi
                         WHERE [Uslugi-Zlecenia].ID_zlecenia = @OrderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        services.Add(new Usluga
                        {
                            ID_uslugi = Convert.ToInt32(reader["ID_uslugi"]),
                            Nazwa_uslugi = reader["Nazwa_uslugi"].ToString(),
                            Cena = Convert.ToDecimal(reader["Cena"])
                        });
                    }
                }
            }
            return services;
        }
        public Rower GetBikeForOrder(int orderId)
        {
            Rower bike = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
            SELECT Rowery.*
            FROM Rowery
            INNER JOIN Zlecenia ON Rowery.ID_roweru = Zlecenia.Rower
            WHERE Zlecenia.ID_zlecenia = @OrderId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bike = new Rower
                        {
                            ID = Convert.ToInt32(reader["ID_roweru"]),
                            Marka = reader["Marka"].ToString(),
                            Model = reader["Model"].ToString(),
                            Kolor = reader["Kolor"].ToString(),
                            Rok_produkcji = Convert.ToInt32(reader["Rok_produkcji"]),
                            Wlasciciel = Convert.ToInt32(reader["Wlasciciel"])
                        };
                    }
                }
            }
            return bike;
        
        }
    }
    }
