using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pendingProds.Class
{
    public class CSimosUser
    {
        private int m_id;
        private String m_user_name;
        private String m_employee_id;
        private int m_id_group;
        private String m_group_name;
        private int m_level;

        public int Id { get => m_id; set => m_id = value; }
        public string User_name { get => m_user_name; set => m_user_name = value; }
        public string Employee_id { get => m_employee_id; set => m_employee_id = value; }
        public int Id_group { get => m_id_group; set => m_id_group = value; }
        public string Group_name { get => m_group_name; set => m_group_name = value; }
        public int Level { get => m_level; set => m_level = value; }
    }
}
