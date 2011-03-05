/* (ORM.NET)
 * AccessorName:BuildStatus
 * This is a one time generated class skeleton by ORM.NET.
 * Please add your business logic for the class here.
 * Please do not remove these comments as they are required by ORM.NET to function correctly.
 */
 
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BuildWolfSandboxBiz
{
	/// <summary>
	/// Wraps a row and it's columns/children/parents
	/// </summary>
	/// <remarks>
	/// This class should not be instantiated directly. See <see cref="DataManager.GetBuildStatus"/>.
	/// This class should be customized.
	/// </remarks>
	public class BuildStatus : BuildStatusOrmTemplate
	{
		/// <summary>
		/// Constructor must have a row and data context.
		/// </summary>
		internal BuildStatus( DataManager dataContext, DataRow ROW) : base( dataContext, ROW)
		{
			row = ROW;
		}
	}
	/// <summary>
	///	Holds a colection of BuildStatuss that can be searched and enemerated.
	/// </summary>
	/// <remarks>
	/// This class should not be instantiated directly. See <see cref="DataManager.GetBuildStatusCollection"/>.
	/// This class can be customized for more specific filters and finds
	/// </remarks>
	public class BuildStatusCollection : BuildStatusCollectionOrmTemplate
	{
	
	}
}
