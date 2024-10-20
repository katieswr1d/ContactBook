using ContactBook.Core.Entity;
using ContactBook.Core.Services;
using ContactBook.DAL.Repositories;

namespace ContactBook.API;

class Program
{
     static void Main(string[] args)
     {
         var service = new ContactService(new FileRepository());

         string option = string.Empty;
         while (option != "0")
         {
             Console.WriteLine("Выберите действие:\n" +
                            "1. Вывести все контакты\n" +
                            "2. Поиск контакта\n" +
                            "3. Добавить новый контакт\n" +
                            "0. Завершить работу");

             option = Console.ReadLine();
             switch (option)
             {
                 case "1":
                     var contacts = service.ReadAll();
                     Console.WriteLine(string.Join("\n", contacts));
                     break;
                 
                 case "2":
                     Console.WriteLine("Выберите опцию:\n" +
                                       "1. Поиск по всем параметрам\n" +
                                       "2. Поиск по конкретному полю");
                     var findOption = Console.ReadLine();
                     if (findOption == "1")
                     {
                         
                     }
                     if (findOption == "2")
                     {
                         Console.WriteLine("Выберите действие:\n" +
                                           "1. Поиск по имени\n" +
                                           "2. Поиск по фамилии\n" +
                                           "3. Поиск по email\n" +
                                           "4. Поиск по номеру телефона");
                         var parameterOption = Console.ReadLine();
                         switch (parameterOption)
                         {
                             case "1":
                                 Console.WriteLine("Введите имя контакта  ");
                                 Console.WriteLine(
                                     $"Found contacts:\n {string.Join('\n', service.FindByFirstName(Console.ReadLine()!))}");
                                 break;
                             case "2":
                                 Console.WriteLine("Введите фамилию контакта  ");
                                 Console.WriteLine(
                                     $"Found contacts:\n {string.Join('\n', service.FindByLastName(Console.ReadLine()!))}");
                                 break;
                             case "3":
                                 Console.WriteLine("Введите email ");
                                 Console.WriteLine(
                                     $"Found contacts:\n {string.Join('\n', service.FindByEmail(Console.ReadLine()!))}");
                                 break;
                             case "4":
                                 Console.WriteLine("Введите номер телефона  ");
                                 Console.WriteLine(
                                     $"Found contacts:\n {string.Join('\n', service.FindByPhone(Console.ReadLine()!))}");
                                 break;
                         }
                     }

                     break;
                 
                 case "3":
                     var contact = new Contact();
                     Console.WriteLine("Введите имя контакта ");
                     var parameter = Console.ReadLine();
                     contact.FirstName = parameter!;
                     Console.WriteLine("Введите фамилию контакта ");
                     parameter = Console.ReadLine();
                     contact.LastName = parameter!;
                     Console.WriteLine("Введите email(0 если закончить) ");
                     parameter = Console.ReadLine();
                     while (parameter != "0")
                     {
                         contact.Email.Add(new Email() { Value = parameter ! });
                         parameter = Console.ReadLine();
                     }

                     Console.WriteLine("Введите номер телефона (0 если закончить) ");
                     while (parameter != "0")
                     {
                         contact.PhoneNumber.Add(new PhoneNumber() { Value = parameter ! });
                         parameter = Console.ReadLine();
                     }

                     service.Create(contact);
                     break;
                 default:
                     break;
                 case "0":
                     
                     break;

             }
             option = Console.ReadLine();
         }
     }
}

