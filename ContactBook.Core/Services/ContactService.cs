﻿using ContactBook.Core.Entity;
using ContactBook.DAL;

namespace ContactBook.Core.Services;

public class ContactService : IContactService
{
    private readonly IRepositoty _repository; //создаем экземпляр класса 


    public ContactService(IRepositoty repository)
    {
        _repository = repository;
    }

    public void Create(Contact contact)
    {
        _repository.Create(contact);
    }

    public IEnumerable<Contact> ReadAll() //метод для получения данных из репозитория
    {
        return _repository.ReadAll();
    }

    public IEnumerable<Contact> FindByAll(string firstName, string lastName, string phoneNumber, string email)
    {
        return _repository.FilterContacts(contact =>
            string.Equals(contact.FirstName, firstName, StringComparison.CurrentCultureIgnoreCase) &&
            string.Equals(contact.LastName, lastName, StringComparison.CurrentCultureIgnoreCase) &&
            contact.PhoneNumber != null &&
            contact.PhoneNumber.Any(phone => phone.Value == phoneNumber) &&
            contact.Email != null &&
            contact.Email.Any(mail => mail.Value == email));
    }
    public IEnumerable<Contact> FindByFirstName(string firstName)//метод для поиска по имени
    {
        return _repository.FilterContacts(contact =>
            string.Equals(contact.FirstName, firstName, StringComparison.CurrentCultureIgnoreCase));
    }

    public IEnumerable<Contact> FindByLastName(string lastName)//метод для поиска по фамилии
    {
        return _repository.FilterContacts(contact =>
            string.Equals(contact.LastName, lastName, StringComparison.CurrentCultureIgnoreCase));
    }


    public IEnumerable<Contact> FindByPhone(string phoneNumber)//метод для поиска по номеру телефона
    {


        return _repository.FilterContacts(contact =>
        {
            foreach (var phone in contact.PhoneNumber)
            {
                if (phone.Value == phoneNumber) return true;
            }

            return false;
        });
    }

    public IEnumerable<Contact> FindByEmail(string email)//метод для поиска по email
    {

        return _repository.FilterContacts(contact =>
        {
            foreach (var mail in contact.Email)
            {
                if (mail.Value == email) return true;
            }

            return false;
        });
    }
}
