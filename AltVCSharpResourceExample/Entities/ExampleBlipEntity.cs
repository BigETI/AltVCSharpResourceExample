using AltV.Net.Elements.Entities;
using System;

/// <summary>
/// alt:V C♯ Resource Example entities namespace
/// </summary>
namespace AltVCSharpResourceExample.Entities
{
    /// <summary>
    /// Example blip entity class
    /// </summary>
    internal class ExampleBlipEntity : Blip, IExampleBlipEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nativePtr">Native pointer</param>
        public ExampleBlipEntity(IntPtr nativePtr) : base(nativePtr)
        {
            // ...
        }
    }
}
