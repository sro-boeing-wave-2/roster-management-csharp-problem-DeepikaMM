using System;
using System.Linq;
using System.Collections.Generic;

namespace RosterManagement
{
    public class CodeSchool
    {
        Dictionary<int, List<string>> _roster;

        public CodeSchool()
        {
            _roster = new Dictionary<int, List<String>>();
        }

        /// <summary>
        /// Should be able to Add Student to a Particular Wave
        /// </summary>
        /// <param name="cadet">Refers to the name of the Cadet</param>
        /// <param name="wave">Refers to the Wave number</param>
        public void Add(string cadet, int wave)

        {
            
           try
            {
               
                _roster[wave].Add(cadet);
                //_roster[wave].Sort();
               
            }
            catch(Exception e)
            {
                List<string> list = new List<string>();
                list.Add(cadet);
                _roster.Add(wave, list);
                

            }

        }

        /// <summary>
        /// Returns all the Cadets in a given wave
        /// </summary>
        /// <param name="wave">Refers to the wave number from where cadet list is to be fetched</param>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Grade(int wave)
        {
            List<string> list=new List<string>();
            if (_roster.ContainsKey(wave))
            {
                 list = _roster[wave];
            }
            var orderByDescendingResult = from c in list
                                          orderby c
                                          select c;
            List<string> list1 = new List<string>(orderByDescendingResult);
            return list1;
        }

        /// <summary>
        /// Return all the cadets in the CodeSchool
        /// </summary>
        /// <returns>List of Cadet's Name</returns>
        public List<string> Roster()
        {
            var cadets = new List<string>();
            SortedDictionary<int, List<string>> roster = new SortedDictionary<int, List<string>>(_roster);
            foreach (List<string> v in roster.Values)
            {
                v.Sort();
                cadets.AddRange(v);
               
            }
           
            return cadets;
            
        }
    }
}
