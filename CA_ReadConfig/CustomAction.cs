using Microsoft.Deployment.WindowsInstaller;
using System.IO;

namespace CA_ReadConfig
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult ReadHost(Session session)
        {
            return ReturnConfigValue(ref session, "SERVICE_HOST", "default", "host");
        }

        [CustomAction]
        public static ActionResult ReadPort(Session session)
        {
            return ReturnConfigValue(ref session, "SERVICE_PORT", "default", "port");
        }

        private static ActionResult ReturnConfigValue(ref Session session, string propertyToSet, string section, string key)
        {
            var path = session["CONFIG_FILE"];

            // do nothing in case path is non existent
            if (!File.Exists(path))
            {
                return ActionResult.Success;
            }
            var config = GetConfig(path);

            session[propertyToSet] = config.IniReadValue(section, key);

            return ActionResult.Success;
        }

        private static INIFile GetConfig(string path)
        {
            return new INIFile(path);
        }
    }
}
