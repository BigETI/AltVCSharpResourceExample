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
    /// Example blip factory class
    /// </summary>
    internal class ExampleBlipFactory : IBaseObjectFactory<IBlip>
    {
        /// <summary>
        /// Create blip
        /// </summary>
        /// <param name="baseObjectPointer">Base object pointer</param>
        /// <returns>Blip</returns>
        public IBlip Create(IntPtr baseObjectPointer) => new ExampleBlipEntity(baseObjectPointer);
    }
}
