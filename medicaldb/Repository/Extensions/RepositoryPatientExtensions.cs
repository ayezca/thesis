using System;
using System.Linq;
using Entities.Models;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryPatientExtensions
    {
        /*public static IQueryable<Patient> FilterEmployees(this IQueryable<Employee> employees, uint minAge, uint maxAge) =>
        employees.Where(e => (e.Age >= minAge && e.Age <= maxAge));*/

        public static IQueryable<Patient> Search(this IQueryable<Patient> patients, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return patients;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return patients.Where(e => e.FirstName.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Patient> Sort(this IQueryable<Patient> patients, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return patients.OrderBy(e => e.FirstName);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Patient).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
                return patients.OrderBy(e => e.FirstName);

            return patients.OrderBy(orderQuery);
        }
    }
}
