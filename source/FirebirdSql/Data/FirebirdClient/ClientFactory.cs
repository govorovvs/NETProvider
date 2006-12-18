/*
 *  Firebird ADO.NET Data provider for .NET and Mono 
 * 
 *     The contents of this file are subject to the Initial 
 *     Developer's Public License Version 1.0 (the "License"); 
 *     you may not use this file except in compliance with the 
 *     License. You may obtain a copy of the License at 
 *     http://www.firebirdsql.org/index.php?op=doc&id=idpl
 *
 *     Software distributed under the License is distributed on 
 *     an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either 
 *     express or implied.  See the License for the specific 
 *     language governing rights and limitations under the License.
 * 
 *  Copyright (c) 2002, 2006 Carlos Guzman Alvarez
 *  All Rights Reserved.
 */

using System;
using FirebirdSql.Data.Common;

namespace FirebirdSql.Data.FirebirdClient
{
	internal sealed class ClientFactory
    {
        #region � Static Methods �

        public static IDatabase CreateDatabase(FbServerType serverType)
        {
            switch (serverType)
            {
                case FbServerType.Default:
                    // C# Client
                    return new FirebirdSql.Data.Client.Gds.GdsDatabase();

#if (!NETCF)

                case FbServerType.Embedded:
                    // PInvoke Client
                    return new FirebirdSql.Data.Client.Embedded.FesDatabase();

                case FbServerType.Context:
                    // External Engine Client
                    return new FirebirdSql.Data.Client.ExternalEngine.ExtDatabase();

#endif

                default:
                    throw new NotSupportedException("Specified server type is not correct.");
            }
        }

        public static IServiceManager CreateServiceManager(FbServerType serverType)
        {
            switch (serverType)
            {
                case FbServerType.Default:
                    // C# Client
                    return new FirebirdSql.Data.Client.Gds.GdsServiceManager();

#if (!NETCF)

                case FbServerType.Embedded:
                    // PInvoke Client
                    return new FirebirdSql.Data.Client.Embedded.FesServiceManager();

#endif

                default:
                    throw new NotSupportedException("Specified server type is not correct.");
            }
        }

        #endregion

        #region � Constructors �

        private ClientFactory()
        {
        }

        #endregion
    }
}
