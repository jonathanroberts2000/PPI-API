namespace PPI_Core.CustomException
{
    using System;
    using PPI_Model.Models;
    using System.Collections.Generic;

    public class RuleException : Exception
    {
        public List<KeyValuePair<string, ErrorModel>> Errors { get; }

        public RuleException(List<KeyValuePair<string, ErrorModel>> errors)
        {
            Errors = errors;
        }
    }
}