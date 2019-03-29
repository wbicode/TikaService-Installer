using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;

namespace CA_ReadConfig
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult ReadHost(Session session)
        {
            var config = GetConfig(session["CONFIG_FILE"]);

            session["SERVICE_HOST"] = config.IniReadValue("default", "host");

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult ReadPort(Session session)
        {
            var config = GetConfig(session["CONFIG_FILE"]);

            session["SERVICE_PORT"] = config.IniReadValue("default", "port");

            return ActionResult.Success;
        }

        private static INIFile GetConfig(string path)
        {
            return new INIFile(path);
        }
    }
}
