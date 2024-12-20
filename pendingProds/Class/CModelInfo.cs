using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pendingProds.Class
{
    class CModelInfo
    {
        private String PART_NUMBER;
        String REVISION;
        String ROUTE_NAME;
        int NB_CIRCUIT_PER_PANEL;
        String PN_DESC;
        String SN_VALIDATION_REGEX;

        public string FG_NAME { get => PART_NUMBER; set => PART_NUMBER = value; }
        public string REV { get => REVISION; set => REVISION = value; }
        public string ROUTE { get => ROUTE_NAME; set => ROUTE_NAME = value; }
        public int NUMBER_BOARDS { get => NB_CIRCUIT_PER_PANEL; set => NB_CIRCUIT_PER_PANEL = value; }
        public string DESCRIPTION { get => PN_DESC; set => PN_DESC = value; }
        public string POKAYOKE { get => SN_VALIDATION_REGEX; set => SN_VALIDATION_REGEX = value; }
    }
}
