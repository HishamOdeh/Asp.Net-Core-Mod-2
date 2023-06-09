﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Asp.Net_Core_Mod_5.Shared
{
    public class ContactResponseDto
    {
        public const string RouteTempGetAll = "api/RepoDb/GetAllContacts";
        public const string RouteTempGetById = "api/RepoDb/GetContactById/{id}";
        public List<ContactDto> Contacts { get; set; }


        public record ContactDto
        {
            //DTO = DataMisalignedException transfer Object
            public Guid Id { get; set; }
            [Required(ErrorMessage = "Last Name is required")]
            public string  LastName { get; set; }
            [Required(ErrorMessage = "First Name is required")]
            public string FirstName { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime BirthDate { get; set; }
            public bool IsActive { get; set; }
            public DateTime? InActivatedDate { get; set; }
        };
        public static IEnumerable<ContactResponseDto.ContactDto> Response(IEnumerable<ContactDto> contacts)
        {
            return contacts.ToList();
            //return JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });

        }
    }
}



/*
 *         public record ContactDto
            (Guid Id,
            string LastName,
            string FirstName,
            string PhoneNumber,
            DateTime BirthDate,
            bool IsActive,
            DateTime? InActivatedDate);

public record ContactDto
{
    //DTO = DataMisalignedException transfer Object
    public Guid Id { get; init; }
    public string LastName { get; init; }
    public string FirstName { get; init; }
    public string PhoneNumber { get; init; }
    public DateTime BirthDate { get; init; }
    public bool IsActive { get; init; }
    public DateTime? InActivatedDate { get; init; }
};*/