using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Xtrl.Azure.DataFactory.Fluent.Interface;
using Xtrl.Azure.DataFactory.Models;

namespace Xtrl.Azure.DataFactory.Fluent
{
    public sealed class AzurePipeline :
        IAzurePipeline,
        IAzureExecutePipeline,
        IAzureSerializeAction,
        IAzureWrite
    {

        private readonly string _name;
        private readonly string _folder;
        private readonly string _propertyDescription;

        private string _filePath;
        private string _jsonData;

        private IList<ActivityModel> _activityModel;

        #region ctor

        private AzurePipeline(string name, string description, string folder)
        {
            _name = name;
            _folder = folder;

            // AzureKeyVault does not store the description in the same JSON
            // node as the other linked services do.
            //
            //if (_azureServiceType == AzureServiceType.AzureKeyVault)
            //    _propertyDescription = description;
            //else
            //    _linkedServiceDescription = description;
            _propertyDescription = description;
        }

        #endregion

        #region Private Methods


        #endregion

        #region Public Static Methods

        public static IAzurePipeline As(string name, string description, string folder) => new AzurePipeline(name, description, folder);

        #endregion

        #region Interface Implementation

        public PipelineModel GetAzurePipeline()
        {
            var myPipeLine = new PipelineModel
            {
                Name = _name,
                Type = "Microsoft.DataFactory/factories/pipelines",

                Properties = new PropertiesModel
                {
                    Activities = _activityModel.ToArray(),
                    PropertyDescription = _propertyDescription,
                    Folder = new Folder
                    {
                        Name = _folder
                    },

                    Annotations = new string[] { }
                }
            };

            return myPipeLine;
        }

        public IAzureWrite ToJson()
        {
            _jsonData = GetAzurePipeline().ToJsonString();
            return this;
        }

        public string ToJsonString()
        {
            _jsonData = GetAzurePipeline().ToJsonString();
            return _jsonData;
        }
        public string ToJsonString(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonData = GetAzurePipeline().ToJsonString(jsonSerializerSettings);
            return _jsonData;
        }

        public IAzureWrite ToJson(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonData = GetAzurePipeline().ToJsonString(jsonSerializerSettings);
            return this;
        }

        public void ToFile(string filePath)
        {
            _filePath = filePath;

            var jsonData = GetAzurePipeline().ToJsonString();
            File.WriteAllText(_filePath, jsonData);
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(_jsonData))
                return _jsonData;

            throw new NotImplementedException();
        }

        private IDictionary<string, object> ParseParameters(string parameters)
        {
            var dictionary = new Dictionary<string, object>();
            var collection = parameters.Split(',');

            foreach (var s in collection)
            {
                var values = s.Split(':');
                dictionary.Add(values[0], values[1]);
            }

            return dictionary;
        }


        public IAzureExecutePipeline AddExecutePipeline(string name, string referenceName, string parameters)
        {
            if (_activityModel == null)
            {
                _activityModel = new List<ActivityModel>();
            }

            var parameterDictionary = ParseParameters(parameters);

            var activityModel = new ActivityModel
            {
                Name = name,
                Type = "ExecutePipeline",
                DependsOn = new DependsOnModel[] { },
                UserProperties = new object[] { },
                TypeProperties = new TypePropertiesModel
                {
                    PipelineReference = new PipelineReferenceModel
                    {
                        ReferenceName = referenceName,
                        Type = "PipelineReference"
                    },
                    WaitOnCompletion = true,
                    Parameters = parameterDictionary
                }
            };

            _activityModel.Add(activityModel);

            return this;
        }

        #endregion
    }
}