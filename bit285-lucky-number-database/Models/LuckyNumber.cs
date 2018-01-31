﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;

namespace lucky_number_database.Models
{
    public class LuckyNumber
    {
        private Random _random = new Random();
        private int[] _spinner = new int[3];
        private decimal _balance;

        [Key] //define the ID for the database (primary key)
        public int LuckyNumberID { get; set; }

        [Display(Name = "Name")] //after adding new data that changes the table we need to make a migration in nuget package manager console (enable-migration)
        public string Name { get; set; }

        [Required] //client and server side validation
        [Display(Name = "Lucky Number")]
        [Range(1,9,ErrorMessage ="The Lucky Number must be a number from 1 to 9")]
        public int Number { get; set; }

        [Required]
        public decimal Balance {
            set
            {
                _balance = value;
            }
            get
            {
                if (_spinner[0] == Number || _spinner[1] == Number || _spinner[2] == Number)
                {
                    _balance += 2;
                }
                return _balance;
            }
        }

        public string Message
        {
            get
            {
               return _balance <= 0 ? "GAME OVER" : ""; //? assigning message to the bool 
            }
        }

        public int[] Spinner
        {
            get
            {
                //Spin up three random numbers
                for (int i = 0;i < 3;i++)
                {
                   _spinner[i] = _random.Next(0, 10);
                }
                return _spinner;
            }
        }
    }
}