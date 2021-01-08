﻿using SQLite;
using System;
using System.Text;

namespace Game_Store_Racz_Christine.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } //the user class has an ID, Email & Password it can be get or set
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public static class UserHelper
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

