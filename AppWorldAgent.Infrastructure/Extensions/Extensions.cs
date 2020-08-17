namespace AppWorldAgent.Infrastructure.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;

    public static class Extensions
    {
        /// <summary>
        /// Find exception in the InnerException
        /// </summary>
        /// <typeparam name="T">Type of the exception to search</typeparam>
        /// <param name="ex">Exception</param>
        /// <returns></returns>
        public static T FindInnerException<T>(this Exception ex) where T : Exception
        {
            if (ex.GetType().Equals(typeof(T)) || ex.GetType().BaseType.Equals(typeof(T)))
                return (T)ex;
            else
            {
                Exception inner = ex.InnerException;

                return inner?.FindInnerException<T>();
            }
        }

        /// <summary>
        /// Convierte una Lista en ObservableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();

            foreach (T item in source)
            {
                collection.Add(item);
            }

            return collection;
        }

        /// <summary>
        /// Convert to Image
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ReadFully(this Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Save image Byte
        /// </summary>
        /// <param name="imageByte"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string SaveFile(this byte[] imageByte, string fileName)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

            File.WriteAllBytes(filePath, imageByte);

            return filePath;
        }

        /// <summary>
        /// Fecha Amigable
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DateFriendly(this DateTime date)
        {
            var months = new List<Month>
            {
                new Month{Id = 1, Name = "Enero" },
                new Month{Id = 2, Name = "Febrero" },
                new Month{Id = 3, Name = "Marzo" },
                new Month{Id = 4, Name = "Abril" },
                new Month{Id = 5, Name = "Mayo" },
                new Month{Id = 6, Name = "Junio" },
                new Month{Id = 7, Name = "Julio" },
                new Month{Id = 8, Name = "Agosto" },
                new Month{Id = 9, Name = "Setiembre" },
                new Month{Id = 10, Name = "Octubre" },
                new Month{Id = 11, Name = "Noviembre" },
                new Month{Id = 12, Name = "Diciembre" }
            };

            return $"{date.Day} de {months.Where(m => m.Id == date.Month).Select(n => n.Name).FirstOrDefault()} del {date.Year}";
        }
    }

    class Month
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
    }
}
