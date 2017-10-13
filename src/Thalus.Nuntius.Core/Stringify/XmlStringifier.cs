using System.Runtime.Serialization;
using Newtonsoft.Json;
using Thalus.Nuntius.Core.Contracts;
using Thalus.Nuntius.Core.Tracing;

namespace Thalus.Nuntius.Core.Stringify
{
    /// <summary>
    /// implements the <see cref="IStringifier{T}"/> functionality for XML
    /// using the <see cref="DataContractSerializer"/> for <see cref="TraceEntryFacade"/>
    /// </summary>
    public class XmlStringifier<TType> : IStringifier<TType>
    {
        string IStringifier<TType>.Stringify(TType obj)
        {
            if (obj == null)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(obj);
            var xml =  JsonConvert.DeserializeXmlNode(json, "trace");

            return xml.InnerXml;
        }
    }
}