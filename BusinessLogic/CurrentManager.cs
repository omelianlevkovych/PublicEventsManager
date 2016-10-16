using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicEventsManager.Entities;

namespace PublicEventsManager.BusinessLogic
{
    public class CurrentManager
    {
        private static Manager currentManager;

        public static void Authorize(Manager manager)
        {
            if (currentManager != null)
            {
                throw new InvalidOperationException("Sorry, manager has been already authorized");
            }

            currentManager = manager;
        }

        /// <summary>
        /// Gets current manager id
        /// </summary>
        public static int Id
        {
            get
            {
                return currentManager.Id;
            }
        }

        /// <summary>
        /// Gets current manager login
        /// </summary>
        public static string Login
        {
            get
            {
                return currentManager.Login;
            }
        }

        /// <summary>
        /// Gets current manager first name
        /// </summary>
        public static string FirstName
        {
            get
            {
                return currentManager.FirstName;
            }
        }

        /// <summary>
        /// Gets current manager last name
        /// </summary>
        public static string LastName
        {
            get
            {
                return currentManager.LastName;
            }
        }

        /// <summary>
        /// Gets indicator if current manager is disabled or not
        /// </summary>
        public static bool IsDisabled
        {
            get
            {
                return currentManager.IsDisabled;
            }
        }
    }
}
