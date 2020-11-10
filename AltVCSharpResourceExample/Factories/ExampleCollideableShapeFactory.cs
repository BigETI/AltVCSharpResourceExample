using AltV.Net;
using AltV.Net.Elements.Entities;
using AltVCSharpResourceExample.Entities;
using System;

/// <summary>
/// alt:V C♯ Resource Example factories namespace
/// </summary>
namespace AltVCSharpResourceExample.Factories
{
    /// <summary>
    /// Example collideable shape factory class
    /// </summary>
    internal class ExampleCollideableShapeFactory : IBaseObjectFactory<IColShape>
    {
        /// <summary>
        /// Create collideable shape
        /// </summary>
        /// <param name="baseObjectPointer">Base object pointer</param>
        /// <returns>Collideable shape</returns>
        public IColShape Create(IntPtr baseObjectPointer) => new ExampleCollideableShapeEntity(baseObjectPointer);
    }
}
