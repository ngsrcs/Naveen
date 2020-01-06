using System;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;

namespace NaveenWPFApp.DataAccessDAL.DTO.Models
{
    public class Person
    {
        private static Random random = new Random();
        [BsonId]
        internal string Id { get; } = GenerateId(24);
        public string FullName { get; set; } = "";
        public int Age { get; set; } = 0;
        public string Country { get; set; } = "";

        // Generate MongoDB ID
        private static string GenerateId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }    
}
