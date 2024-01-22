using CarStream.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CarStream.Repository.Interfaces
{
    public interface IModelRepository
    {
        void SaveModels(List<Model> models, string filePath);
        List<Model> LoadModels(string filePath);
    }
}
