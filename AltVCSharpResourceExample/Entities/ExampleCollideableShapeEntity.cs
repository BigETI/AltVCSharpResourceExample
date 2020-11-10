using AltV.Net.Elements.Entities;
using System;

/// <summary>
/// alt:V C♯ Resource Example entities namespace
/// </summary>
namespace AltVCSharpResourceExample.Entities
{
    /// <summary>
    /// Example collideable shape entity class
    /// </summary>
    internal class ExampleCollideableShapeEntity : ColShape, IExampleColleadableShapeEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nativePointer">Native pointer</param>
        public ExampleCollideableShapeEntity(IntPtr nativePointer) : base(nativePointer)
        {
            // ...
        }
    }
}
