namespace PPI_Core
{
    using System;
    using System.Threading;
    using PPI_Model.Models;
    using PPI_API.UnitOfWork;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Extensions.Hosting;

    public class Globals : IHostedService
    {
        private readonly Timer timer;
        private readonly object _lock = new();
        private readonly IUnitOfWork unitOfWork;

        private List<int> availableAssetIds;
        private List<ErrorModel> errorMessages;

        public List<int> AvailableAssetIds
        {
            get
            {
                if(availableAssetIds == null || availableAssetIds?.Count == 0)
                {
                    availableAssetIds = (List<int>)unitOfWork.Asset.GetAssetIds();
                }
                return availableAssetIds;
            }
            private set
            {
                availableAssetIds = value;
            }
        }

        public List<ErrorModel> ErrorMessages
        {
            get
            {
                if(errorMessages == null || errorMessages?.Count == 0)
                {
                    errorMessages = (List<ErrorModel>)unitOfWork.Rule.GetErrorMessages();
                }
                return errorMessages;
            }
            private set
            {
                errorMessages = value;
            }
        }

        public Globals(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            timer = new Timer(BindGlobals, null, TimeSpan.Zero, TimeSpan.FromMinutes(10));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            return Task.CompletedTask;
        }

        private void BindGlobals(object state)
        {
            lock (_lock)
            {
                AvailableAssetIds = (List<int>)unitOfWork.Asset.GetAssetIds();
                ErrorMessages = (List<ErrorModel>)unitOfWork.Rule.GetErrorMessages();
            }
        }
    }
}