// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.IO;
using YamlDotNet.Serialization;

namespace Microsoft.Docs.Build
{
    internal static class LegacyXrefMap
    {
        public static void Convert(Docset docset, Context context, XrefMap xrefMap)
        {
            var map = new XrefMapModel();
            map.References.AddRange(xrefMap.References);

            using (var writer = new StreamWriter(context.WriteStream(Path.Combine(docset.Config.SiteBasePath, "xrefmap.yml"))))
            {
                writer.WriteLine("### YamlMime:XRefMap");
                var serializer = new SerializerBuilder().Build();
                serializer.Serialize(writer, map);
            }
        }
    }
}
