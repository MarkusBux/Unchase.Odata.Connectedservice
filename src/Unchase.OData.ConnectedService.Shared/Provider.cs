﻿// Copyright (c) 2018 Unchase (https://github.com/unchase).  All rights reserved.
// Licensed under the Apache License 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.ConnectedServices;
using Unchase.OData.ConnectedService.Common;
#if VS17
using Unchase.OData.ConnectedService.VS22.Properties;
#else
using Unchase.OData.ConnectedService.Properties;
#endif

namespace Unchase.OData.ConnectedService
{
    [ConnectedServiceProviderExport(Constants.ProviderId, SupportsUpdate = true)]
    internal class Provider : ConnectedServiceProvider
    {
        #region Constructors

        public Provider()
        {
            Category = Constants.ExtensionCategory;
            Name = Constants.ExtensionName;
            Description = Constants.ExtensionDescription;
            Icon = Imaging.CreateBitmapSourceFromHBitmap(
                Resources.preview_200x200.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromWidthAndHeight(64, 64)
            );
            CreatedBy = Constants.Author;
            Version = typeof(Provider).Assembly.GetName().Version;
            MoreInfoUri = new Uri(Constants.Website);
        }

        #endregion

        #region Methods

        public override IEnumerable<Tuple<string, Uri>> GetSupportedTechnologyLinks()
        {
            yield return Tuple.Create("OData Website", new Uri("http://www.odata.org/"));
            yield return Tuple.Create("OData Docs and Samples", new Uri("http://odata.github.io/odata.net/"));
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            var wizard = new Wizard(context);
            return Task.FromResult<ConnectedServiceConfigurator>(wizard);
        }

        #endregion
    }
}
