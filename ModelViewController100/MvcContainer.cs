using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace ModelViewController100
{
    public class MvcContainer
    {
        List<Type> _listControllerType = new List<Type>();

        public MvcContainer()
        {
            var typeController = typeof(Controller);

            _listControllerType = typeController.Assembly.GetTypes()
                                .Where(x => !x.IsAbstract
                                    && typeController.IsAssignableFrom(x)
                                    ).ToList();
        }

        public object Resolve(Uri uri)
        {
            var controller = GetController(uri);
            var action = GetAction(controller, uri);
            var parameters = GetParameters(action, uri);
            return action.Invoke(controller, parameters);
        }


        public Controller GetController(Uri uri)
        {
            var typeController = _listControllerType.FirstOrDefault(x => uri.AbsolutePath
                                    .StartsWith($"/{x.Name.Replace("Controller", "")}",
                                        StringComparison.InvariantCultureIgnoreCase));
            return (Controller)Activator.CreateInstance(typeController, null);
        }

        public MethodInfo GetAction(Controller controller, Uri uri)
        {
            var filter = uri.AbsolutePath.Split('/', StringSplitOptions.RemoveEmptyEntries).Last();
            return controller.GetType().GetMethods().FirstOrDefault(x => x.Name.Equals(filter, StringComparison.InvariantCultureIgnoreCase));
        }

        private object[] GetParameters(MethodInfo method, Uri uri)
        {
            var parameterInfos = method.GetParameters().ToList();
            if (parameterInfos.Count == 0)
            {
                return null;
            }
            var results = new object[parameterInfos.Count];
            var query = HttpUtility.ParseQueryString(uri.Query);

            for (int i = 0; i < parameterInfos.Count; i++)
            {
                var p = parameterInfos[i];
                var t = parameterInfos[i].ParameterType;
                var value = query[p.Name];

                if (t == typeof(String))
                {
                    results[i] = value;
                }
                else if (t == typeof(Int32))
                {
                    results[i] = Int32.Parse(value);
                }
            }
            return results;
        }
    }
}
