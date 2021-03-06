﻿using DevExpress.Utils;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraPdfViewer.Commands;

namespace ViewerCustomCommand {
    public class CustomPdfViewerCommandFactoryService : IPdfViewerCommandFactoryService {
        readonly IPdfViewerCommandFactoryService service;
        readonly PdfViewer control;

        public CustomPdfViewerCommandFactoryService(PdfViewer control,
            IPdfViewerCommandFactoryService service) {
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(service, "service");
            this.control = control;
            this.service = service;
        }

        public PdfViewerCommand CreateCommand(PdfViewerCommandId id) {
            if (id == PdfViewerCommandId.NextPage)
                return new CustomNextPageCommand(control);

            return service.CreateCommand(id);
        }
    }
}
