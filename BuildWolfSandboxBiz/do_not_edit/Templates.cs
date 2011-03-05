using System;
using System.Data;
using System.Data.SqlTypes;
using System.Collections;
using System.ComponentModel;

namespace BuildWolfSandboxBiz
{


	/// <summary>
	/// Wraps a datarow, exposing it's richest features as properties and methods.
	/// </summary>
	public abstract class BuildsOrmTemplate : Business
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="dataContext">The DataManager this object should perform it's operations with</param>
		/// <param name="ROW">The underlying row that this object will wrap</param>
		internal BuildsOrmTemplate( DataManager dataContext, DataRow ROW) : base(dataContext) 
		{ 
			row = ROW; 
		}


		/// <summary>
		/// Gets and sets the property at the underlying row index.
		/// </summary>
		public object this[int index]
		{
			get
			{
				if ( this.row.IsNull(index) )
					return null;
				else
					return this.row[index];
			}
			set
			{
				if ( value == null )
					this.row[index] = DBNull.Value;
				else
					this.row[index] = value;
			}
		}

		/// <summary>
		/// Gets and sets the property by its name.
		/// </summary>
		/// <remarks>
		/// Do not use the underlying column name if it is different.
		/// </remarks>
		public object this[string property]
		{
			get
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanRead )
					return pi.GetValue(this, null);

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Get" + property,new System.Type[]{});
								
				if ( mi != null )
					return mi.Invoke(this, null);

				return null;
			}
			set
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanWrite )
				{
					pi.SetValue(this, value, null);
					return;
				}

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Set" + property,new System.Type[]{value.GetType()});
								
				if ( mi != null )
					mi.Invoke(this, new object[]{value});
			}
		}		

		
		/// <summary>
		/// Returns true if the underlying DataRow.RowState is marked as DataRowState.Deleted
		/// </summary>
		/// <returns>true if deleted</returns>
		public virtual bool IsDeleted()
		{
			return row.RowState == DataRowState.Deleted;
		}

		/// <summary>
		/// Gets and Sets the id.
		/// </summary>
		/// <value>
		/// The underlying rows id cell
		/// </value>
		public virtual System.Int32 id 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return (System.Int32) row["id"]; 
				else
					return (System.Int32) row["id", DataRowVersion.Original];
				
				//System.Int32 
			} 
			set
			{ 
				row["id"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the Status.
		/// </summary>
		/// <value>
		/// The underlying rows Status cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlInt32 Status 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("Status"))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["Status"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["Status"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["Status", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["Status"] = DBNull.Value;
				else
					row["Status"] = value.Value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the CreationDate.
		/// </summary>
		/// <value>
		/// The underlying rows CreationDate cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlDateTime CreationDate 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("CreationDate"))
						return System.Data.SqlTypes.SqlDateTime.Null;
					else
						return new System.Data.SqlTypes.SqlDateTime((System.DateTime)row["CreationDate"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["CreationDate"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlDateTime.Null;
					else
						return new System.Data.SqlTypes.SqlDateTime((System.DateTime)row["CreationDate", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["CreationDate"] = DBNull.Value;
				else
					row["CreationDate"] = value.Value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the CreatedBy.
		/// </summary>
		/// <value>
		/// The underlying rows CreatedBy cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlInt32 CreatedBy 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("CreatedBy"))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["CreatedBy"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["CreatedBy"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["CreatedBy", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["CreatedBy"] = DBNull.Value;
				else
					row["CreatedBy"] = value.Value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the CreatedByComputerName.
		/// </summary>
		/// <value>
		/// The underlying rows CreatedByComputerName cell
		/// </value>
		public virtual System.String CreatedByComputerName 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("CreatedByComputerName") ? null : (System.String) row["CreatedByComputerName"]; 
				else
					return row.IsNull(row.Table.Columns["CreatedByComputerName"], DataRowVersion.Original) ? null : (System.String) row["CreatedByComputerName", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["CreatedByComputerName"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the CreatorsLocalBranchRoot.
		/// </summary>
		/// <value>
		/// The underlying rows CreatorsLocalBranchRoot cell
		/// </value>
		public virtual System.String CreatorsLocalBranchRoot 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("CreatorsLocalBranchRoot") ? null : (System.String) row["CreatorsLocalBranchRoot"]; 
				else
					return row.IsNull(row.Table.Columns["CreatorsLocalBranchRoot"], DataRowVersion.Original) ? null : (System.String) row["CreatorsLocalBranchRoot", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["CreatorsLocalBranchRoot"] = value; 
 
			} 
		}
		
		/// <summary>
		/// Gets and Sets the parent BuildWolfSandboxBiz.BuildStatus.
		/// </summary>
		 
		public virtual BuildWolfSandboxBiz.BuildStatus BuildStatus
		{
			get
			{
				if (row.GetParentRow(base.DataSet.Relations["StatusBuilds"]) != null)
					return new BuildWolfSandboxBiz.BuildStatus( DataContext, row.GetParentRow("StatusBuilds"));
				else
					return null;
			}
			set
			{
				if ( value == null )
				{
					row.SetParentRow(null, base.DataSet.Relations["StatusBuilds"] );
				}
				else
					row.SetParentRow( value.row, base.DataSet.Relations["StatusBuilds"] );			
			}
		}
	
		
		/// <summary>
		/// Gets and Sets the parent BuildWolfSandboxBiz.Users.
		/// </summary>
		 
		public virtual BuildWolfSandboxBiz.Users Users
		{
			get
			{
				if (row.GetParentRow(base.DataSet.Relations["CreatedByBuilds"]) != null)
					return new BuildWolfSandboxBiz.Users( DataContext, row.GetParentRow("CreatedByBuilds"));
				else
					return null;
			}
			set
			{
				if ( value == null )
				{
					row.SetParentRow(null, base.DataSet.Relations["CreatedByBuilds"] );
				}
				else
					row.SetParentRow( value.row, base.DataSet.Relations["CreatedByBuilds"] );			
			}
		}
	

	}



	/// <summary>
	/// Wraps a datarow, exposing it's richest features as properties and methods.
	/// </summary>
	public abstract class BuildStatusOrmTemplate : Business
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="dataContext">The DataManager this object should perform it's operations with</param>
		/// <param name="ROW">The underlying row that this object will wrap</param>
		internal BuildStatusOrmTemplate( DataManager dataContext, DataRow ROW) : base(dataContext) 
		{ 
			row = ROW; 
		}


		/// <summary>
		/// Gets and sets the property at the underlying row index.
		/// </summary>
		public object this[int index]
		{
			get
			{
				if ( this.row.IsNull(index) )
					return null;
				else
					return this.row[index];
			}
			set
			{
				if ( value == null )
					this.row[index] = DBNull.Value;
				else
					this.row[index] = value;
			}
		}

		/// <summary>
		/// Gets and sets the property by its name.
		/// </summary>
		/// <remarks>
		/// Do not use the underlying column name if it is different.
		/// </remarks>
		public object this[string property]
		{
			get
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanRead )
					return pi.GetValue(this, null);

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Get" + property,new System.Type[]{});
								
				if ( mi != null )
					return mi.Invoke(this, null);

				return null;
			}
			set
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanWrite )
				{
					pi.SetValue(this, value, null);
					return;
				}

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Set" + property,new System.Type[]{value.GetType()});
								
				if ( mi != null )
					mi.Invoke(this, new object[]{value});
			}
		}		

		
		/// <summary>
		/// Returns true if the underlying DataRow.RowState is marked as DataRowState.Deleted
		/// </summary>
		/// <returns>true if deleted</returns>
		public virtual bool IsDeleted()
		{
			return row.RowState == DataRowState.Deleted;
		}

		/// <summary>
		/// Gets and Sets the id.
		/// </summary>
		/// <value>
		/// The underlying rows id cell
		/// </value>
		public virtual System.Int32 id 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return (System.Int32) row["id"]; 
				else
					return (System.Int32) row["id", DataRowVersion.Original];
				
				//System.Int32 
			} 
			set
			{ 
				row["id"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the StatusName.
		/// </summary>
		/// <value>
		/// The underlying rows StatusName cell
		/// </value>
		public virtual System.String StatusName 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("StatusName") ? null : (System.String) row["StatusName"]; 
				else
					return row.IsNull(row.Table.Columns["StatusName"], DataRowVersion.Original) ? null : (System.String) row["StatusName", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["StatusName"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the StatusDescription.
		/// </summary>
		/// <value>
		/// The underlying rows StatusDescription cell
		/// </value>
		public virtual System.String StatusDescription 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("StatusDescription") ? null : (System.String) row["StatusDescription"]; 
				else
					return row.IsNull(row.Table.Columns["StatusDescription"], DataRowVersion.Original) ? null : (System.String) row["StatusDescription", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["StatusDescription"] = value; 
 
			} 
		}
		private BuildWolfSandboxBiz.BuildsCollection _Buildss = null;
	
		/// <summary>
		/// Refreshes the collection of Buildss from the underlying dataset
		/// </summary>
		internal void refreshBuildss()
		{
			if (_Buildss == null) _Buildss = new BuildWolfSandboxBiz.BuildsCollection();
			
			((IList)_Buildss).Clear();

			DataRow[] cr = row.GetChildRows("StatusBuilds");
			foreach( DataRow chld in cr)
			{
				BuildWolfSandboxBiz.Builds obj = new BuildWolfSandboxBiz.Builds(base.DataContext, chld);
				_Buildss.Add( obj );
			}
			
			// add after, so that events wont be fired
			_Buildss.Parent = this;
		}
				
		/// <summary>
		/// Exposes the collection of child BuildWolfSandboxBiz.Buildss.
		/// </summary>
		public virtual BuildWolfSandboxBiz.BuildsCollection Buildss
		{
			get 
			{ 
				if (_Buildss == null) refreshBuildss();

				return _Buildss;
			}
		}


			/// <summary>
			/// Adds a BuildWolfSandboxBiz.Builds to the collection.
			/// </summary>
			public virtual int AddBuilds(BuildWolfSandboxBiz.Builds newBuilds)
			{
				if ( _Buildss == null ) refreshBuildss();

				if ( newBuilds.row.GetParentRow(base.DataSet.Relations["StatusBuilds"]) == row )
					return _Buildss.IndexOf( newBuilds );

				newBuilds.row.SetParentRow(row,base.DataSet.Relations["StatusBuilds"]);

				int index = _Buildss.Add( newBuilds );

				return index;

			}

			/// <summary>
			/// Creates a new BuildWolfSandboxBiz.Builds, adding it to the collection.
			/// </summary>
			/// <remarks>
			/// CommitAll() must be called to persist this to the database.
			/// </remarks>
			/// <returns>A new Builds object</returns>
			public virtual BuildWolfSandboxBiz.Builds NewBuilds()
			{
				if ( _Buildss == null ) refreshBuildss();

				BuildWolfSandboxBiz.Builds newBuilds = new BuildWolfSandboxBiz.Builds(base.DataContext, base.DataSet.Tables["Builds"].NewRow());
				base.DataSet.Tables["Builds"].Rows.Add(newBuilds.row);
				
				this.AddBuilds(newBuilds);

				return newBuilds;
			}
	

	}



	/// <summary>
	/// Wraps a datarow, exposing it's richest features as properties and methods.
	/// </summary>
	public abstract class CommentsOrmTemplate : Business
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="dataContext">The DataManager this object should perform it's operations with</param>
		/// <param name="ROW">The underlying row that this object will wrap</param>
		internal CommentsOrmTemplate( DataManager dataContext, DataRow ROW) : base(dataContext) 
		{ 
			row = ROW; 
		}


		/// <summary>
		/// Gets and sets the property at the underlying row index.
		/// </summary>
		public object this[int index]
		{
			get
			{
				if ( this.row.IsNull(index) )
					return null;
				else
					return this.row[index];
			}
			set
			{
				if ( value == null )
					this.row[index] = DBNull.Value;
				else
					this.row[index] = value;
			}
		}

		/// <summary>
		/// Gets and sets the property by its name.
		/// </summary>
		/// <remarks>
		/// Do not use the underlying column name if it is different.
		/// </remarks>
		public object this[string property]
		{
			get
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanRead )
					return pi.GetValue(this, null);

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Get" + property,new System.Type[]{});
								
				if ( mi != null )
					return mi.Invoke(this, null);

				return null;
			}
			set
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanWrite )
				{
					pi.SetValue(this, value, null);
					return;
				}

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Set" + property,new System.Type[]{value.GetType()});
								
				if ( mi != null )
					mi.Invoke(this, new object[]{value});
			}
		}		

		
		/// <summary>
		/// Returns true if the underlying DataRow.RowState is marked as DataRowState.Deleted
		/// </summary>
		/// <returns>true if deleted</returns>
		public virtual bool IsDeleted()
		{
			return row.RowState == DataRowState.Deleted;
		}

		/// <summary>
		/// Gets and Sets the id.
		/// </summary>
		/// <value>
		/// The underlying rows id cell
		/// </value>
		public virtual System.Int32 id 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return (System.Int32) row["id"]; 
				else
					return (System.Int32) row["id", DataRowVersion.Original];
				
				//System.Int32 
			} 
			set
			{ 
				row["id"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the CommentText.
		/// </summary>
		/// <value>
		/// The underlying rows CommentText cell
		/// </value>
		public virtual System.String CommentText 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("CommentText") ? null : (System.String) row["CommentText"]; 
				else
					return row.IsNull(row.Table.Columns["CommentText"], DataRowVersion.Original) ? null : (System.String) row["CommentText", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["CommentText"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the CommentTime.
		/// </summary>
		/// <value>
		/// The underlying rows CommentTime cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlDateTime CommentTime 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("CommentTime"))
						return System.Data.SqlTypes.SqlDateTime.Null;
					else
						return new System.Data.SqlTypes.SqlDateTime((System.DateTime)row["CommentTime"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["CommentTime"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlDateTime.Null;
					else
						return new System.Data.SqlTypes.SqlDateTime((System.DateTime)row["CommentTime", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["CommentTime"] = DBNull.Value;
				else
					row["CommentTime"] = value.Value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the AuthorUserID.
		/// </summary>
		/// <value>
		/// The underlying rows AuthorUserID cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlInt32 AuthorUserID 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("AuthorUserID"))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["AuthorUserID"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["AuthorUserID"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["AuthorUserID", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["AuthorUserID"] = DBNull.Value;
				else
					row["AuthorUserID"] = value.Value; 
 
			} 
		}
		
		/// <summary>
		/// Gets and Sets the parent BuildWolfSandboxBiz.Users.
		/// </summary>
		 
		public virtual BuildWolfSandboxBiz.Users Users
		{
			get
			{
				if (row.GetParentRow(base.DataSet.Relations["AuthorUserIDComments"]) != null)
					return new BuildWolfSandboxBiz.Users( DataContext, row.GetParentRow("AuthorUserIDComments"));
				else
					return null;
			}
			set
			{
				if ( value == null )
				{
					row.SetParentRow(null, base.DataSet.Relations["AuthorUserIDComments"] );
				}
				else
					row.SetParentRow( value.row, base.DataSet.Relations["AuthorUserIDComments"] );			
			}
		}
	

	}



	/// <summary>
	/// Wraps a datarow, exposing it's richest features as properties and methods.
	/// </summary>
	public abstract class GroupsOrmTemplate : Business
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="dataContext">The DataManager this object should perform it's operations with</param>
		/// <param name="ROW">The underlying row that this object will wrap</param>
		internal GroupsOrmTemplate( DataManager dataContext, DataRow ROW) : base(dataContext) 
		{ 
			row = ROW; 
		}


		/// <summary>
		/// Gets and sets the property at the underlying row index.
		/// </summary>
		public object this[int index]
		{
			get
			{
				if ( this.row.IsNull(index) )
					return null;
				else
					return this.row[index];
			}
			set
			{
				if ( value == null )
					this.row[index] = DBNull.Value;
				else
					this.row[index] = value;
			}
		}

		/// <summary>
		/// Gets and sets the property by its name.
		/// </summary>
		/// <remarks>
		/// Do not use the underlying column name if it is different.
		/// </remarks>
		public object this[string property]
		{
			get
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanRead )
					return pi.GetValue(this, null);

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Get" + property,new System.Type[]{});
								
				if ( mi != null )
					return mi.Invoke(this, null);

				return null;
			}
			set
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanWrite )
				{
					pi.SetValue(this, value, null);
					return;
				}

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Set" + property,new System.Type[]{value.GetType()});
								
				if ( mi != null )
					mi.Invoke(this, new object[]{value});
			}
		}		

		
		/// <summary>
		/// Returns true if the underlying DataRow.RowState is marked as DataRowState.Deleted
		/// </summary>
		/// <returns>true if deleted</returns>
		public virtual bool IsDeleted()
		{
			return row.RowState == DataRowState.Deleted;
		}

		/// <summary>
		/// Gets and Sets the id.
		/// </summary>
		/// <value>
		/// The underlying rows id cell
		/// </value>
		public virtual System.Int32 id 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return (System.Int32) row["id"]; 
				else
					return (System.Int32) row["id", DataRowVersion.Original];
				
				//System.Int32 
			} 
			set
			{ 
				row["id"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the GroupName.
		/// </summary>
		/// <value>
		/// The underlying rows GroupName cell
		/// </value>
		public virtual System.String GroupName 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("GroupName") ? null : (System.String) row["GroupName"]; 
				else
					return row.IsNull(row.Table.Columns["GroupName"], DataRowVersion.Original) ? null : (System.String) row["GroupName", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["GroupName"] = value; 
 
			} 
		}
		private BuildWolfSandboxBiz.TagsCollection _Tagss = null;
	
		/// <summary>
		/// Refreshes the collection of Tagss from the underlying dataset
		/// </summary>
		internal void refreshTagss()
		{
			if (_Tagss == null) _Tagss = new BuildWolfSandboxBiz.TagsCollection();
			
			((IList)_Tagss).Clear();

			DataRow[] cr = row.GetChildRows("GroupsAllowedToSetTags");
			foreach( DataRow chld in cr)
			{
				BuildWolfSandboxBiz.Tags obj = new BuildWolfSandboxBiz.Tags(base.DataContext, chld);
				_Tagss.Add( obj );
			}
			
			// add after, so that events wont be fired
			_Tagss.Parent = this;
		}
				
		/// <summary>
		/// Exposes the collection of child BuildWolfSandboxBiz.Tagss.
		/// </summary>
		public virtual BuildWolfSandboxBiz.TagsCollection Tagss
		{
			get 
			{ 
				if (_Tagss == null) refreshTagss();

				return _Tagss;
			}
		}


			/// <summary>
			/// Adds a BuildWolfSandboxBiz.Tags to the collection.
			/// </summary>
			public virtual int AddTags(BuildWolfSandboxBiz.Tags newTags)
			{
				if ( _Tagss == null ) refreshTagss();

				if ( newTags.row.GetParentRow(base.DataSet.Relations["GroupsAllowedToSetTags"]) == row )
					return _Tagss.IndexOf( newTags );

				newTags.row.SetParentRow(row,base.DataSet.Relations["GroupsAllowedToSetTags"]);

				int index = _Tagss.Add( newTags );

				return index;

			}

			/// <summary>
			/// Creates a new BuildWolfSandboxBiz.Tags, adding it to the collection.
			/// </summary>
			/// <remarks>
			/// CommitAll() must be called to persist this to the database.
			/// </remarks>
			/// <returns>A new Tags object</returns>
			public virtual BuildWolfSandboxBiz.Tags NewTags()
			{
				if ( _Tagss == null ) refreshTagss();

				BuildWolfSandboxBiz.Tags newTags = new BuildWolfSandboxBiz.Tags(base.DataContext, base.DataSet.Tables["Tags"].NewRow());
				base.DataSet.Tables["Tags"].Rows.Add(newTags.row);
				
				this.AddTags(newTags);

				return newTags;
			}
	
		private BuildWolfSandboxBiz.UsersCollection _Userss = null;
	
		/// <summary>
		/// Refreshes the collection of Userss from the underlying dataset
		/// </summary>
		internal void refreshUserss()
		{
			if (_Userss == null) _Userss = new BuildWolfSandboxBiz.UsersCollection();
			
			((IList)_Userss).Clear();

			DataRow[] cr = row.GetChildRows("GroupIDUsers");
			foreach( DataRow chld in cr)
			{
				BuildWolfSandboxBiz.Users obj = new BuildWolfSandboxBiz.Users(base.DataContext, chld);
				_Userss.Add( obj );
			}
			
			// add after, so that events wont be fired
			_Userss.Parent = this;
		}
				
		/// <summary>
		/// Exposes the collection of child BuildWolfSandboxBiz.Userss.
		/// </summary>
		public virtual BuildWolfSandboxBiz.UsersCollection Userss
		{
			get 
			{ 
				if (_Userss == null) refreshUserss();

				return _Userss;
			}
		}


			/// <summary>
			/// Adds a BuildWolfSandboxBiz.Users to the collection.
			/// </summary>
			public virtual int AddUsers(BuildWolfSandboxBiz.Users newUsers)
			{
				if ( _Userss == null ) refreshUserss();

				if ( newUsers.row.GetParentRow(base.DataSet.Relations["GroupIDUsers"]) == row )
					return _Userss.IndexOf( newUsers );

				newUsers.row.SetParentRow(row,base.DataSet.Relations["GroupIDUsers"]);

				int index = _Userss.Add( newUsers );

				return index;

			}

			/// <summary>
			/// Creates a new BuildWolfSandboxBiz.Users, adding it to the collection.
			/// </summary>
			/// <remarks>
			/// CommitAll() must be called to persist this to the database.
			/// </remarks>
			/// <returns>A new Users object</returns>
			public virtual BuildWolfSandboxBiz.Users NewUsers()
			{
				if ( _Userss == null ) refreshUserss();

				BuildWolfSandboxBiz.Users newUsers = new BuildWolfSandboxBiz.Users(base.DataContext, base.DataSet.Tables["Users"].NewRow());
				base.DataSet.Tables["Users"].Rows.Add(newUsers.row);
				
				this.AddUsers(newUsers);

				return newUsers;
			}
	

	}



	/// <summary>
	/// Wraps a datarow, exposing it's richest features as properties and methods.
	/// </summary>
	public abstract class PlatformsOrmTemplate : Business
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="dataContext">The DataManager this object should perform it's operations with</param>
		/// <param name="ROW">The underlying row that this object will wrap</param>
		internal PlatformsOrmTemplate( DataManager dataContext, DataRow ROW) : base(dataContext) 
		{ 
			row = ROW; 
		}


		/// <summary>
		/// Gets and sets the property at the underlying row index.
		/// </summary>
		public object this[int index]
		{
			get
			{
				if ( this.row.IsNull(index) )
					return null;
				else
					return this.row[index];
			}
			set
			{
				if ( value == null )
					this.row[index] = DBNull.Value;
				else
					this.row[index] = value;
			}
		}

		/// <summary>
		/// Gets and sets the property by its name.
		/// </summary>
		/// <remarks>
		/// Do not use the underlying column name if it is different.
		/// </remarks>
		public object this[string property]
		{
			get
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanRead )
					return pi.GetValue(this, null);

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Get" + property,new System.Type[]{});
								
				if ( mi != null )
					return mi.Invoke(this, null);

				return null;
			}
			set
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanWrite )
				{
					pi.SetValue(this, value, null);
					return;
				}

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Set" + property,new System.Type[]{value.GetType()});
								
				if ( mi != null )
					mi.Invoke(this, new object[]{value});
			}
		}		

		
		/// <summary>
		/// Returns true if the underlying DataRow.RowState is marked as DataRowState.Deleted
		/// </summary>
		/// <returns>true if deleted</returns>
		public virtual bool IsDeleted()
		{
			return row.RowState == DataRowState.Deleted;
		}

		/// <summary>
		/// Gets and Sets the id.
		/// </summary>
		/// <value>
		/// The underlying rows id cell
		/// </value>
		public virtual System.Int32 id 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return (System.Int32) row["id"]; 
				else
					return (System.Int32) row["id", DataRowVersion.Original];
				
				//System.Int32 
			} 
			set
			{ 
				row["id"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the PlatformName.
		/// </summary>
		/// <value>
		/// The underlying rows PlatformName cell
		/// </value>
		public virtual System.String PlatformName 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("PlatformName") ? null : (System.String) row["PlatformName"]; 
				else
					return row.IsNull(row.Table.Columns["PlatformName"], DataRowVersion.Original) ? null : (System.String) row["PlatformName", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["PlatformName"] = value; 
 
			} 
		}

	}



	/// <summary>
	/// Wraps a datarow, exposing it's richest features as properties and methods.
	/// </summary>
	public abstract class sysdiagramsOrmTemplate : Business
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="dataContext">The DataManager this object should perform it's operations with</param>
		/// <param name="ROW">The underlying row that this object will wrap</param>
		internal sysdiagramsOrmTemplate( DataManager dataContext, DataRow ROW) : base(dataContext) 
		{ 
			row = ROW; 
		}


		/// <summary>
		/// Gets and sets the property at the underlying row index.
		/// </summary>
		public object this[int index]
		{
			get
			{
				if ( this.row.IsNull(index) )
					return null;
				else
					return this.row[index];
			}
			set
			{
				if ( value == null )
					this.row[index] = DBNull.Value;
				else
					this.row[index] = value;
			}
		}

		/// <summary>
		/// Gets and sets the property by its name.
		/// </summary>
		/// <remarks>
		/// Do not use the underlying column name if it is different.
		/// </remarks>
		public object this[string property]
		{
			get
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanRead )
					return pi.GetValue(this, null);

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Get" + property,new System.Type[]{});
								
				if ( mi != null )
					return mi.Invoke(this, null);

				return null;
			}
			set
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanWrite )
				{
					pi.SetValue(this, value, null);
					return;
				}

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Set" + property,new System.Type[]{value.GetType()});
								
				if ( mi != null )
					mi.Invoke(this, new object[]{value});
			}
		}		

		
		/// <summary>
		/// Returns true if the underlying DataRow.RowState is marked as DataRowState.Deleted
		/// </summary>
		/// <returns>true if deleted</returns>
		public virtual bool IsDeleted()
		{
			return row.RowState == DataRowState.Deleted;
		}

		/// <summary>
		/// Gets and Sets the name.
		/// </summary>
		/// <value>
		/// The underlying rows name cell
		/// </value>
		public virtual System.String name 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("name") ? null : (System.String) row["name"]; 
				else
					return row.IsNull(row.Table.Columns["name"], DataRowVersion.Original) ? null : (System.String) row["name", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["name"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the principal_id.
		/// </summary>
		/// <value>
		/// The underlying rows principal_id cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlInt32 principal_id 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("principal_id"))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["principal_id"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["principal_id"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["principal_id", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["principal_id"] = DBNull.Value;
				else
					row["principal_id"] = value.Value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the diagram_id.
		/// </summary>
		/// <value>
		/// The underlying rows diagram_id cell
		/// </value>
		public virtual System.Int32 diagram_id 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return (System.Int32) row["diagram_id"]; 
				else
					return (System.Int32) row["diagram_id", DataRowVersion.Original];
				
				//System.Int32 
			} 
			set
			{ 
				row["diagram_id"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the version.
		/// </summary>
		/// <value>
		/// The underlying rows version cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlInt32 version 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("version"))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["version"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["version"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["version", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["version"] = DBNull.Value;
				else
					row["version"] = value.Value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the definition.
		/// </summary>
		/// <value>
		/// The underlying rows definition cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlBinary definition 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("definition"))
						return System.Data.SqlTypes.SqlBinary.Null;
					else
						return new System.Data.SqlTypes.SqlBinary((System.Byte[])row["definition"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["definition"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlBinary.Null;
					else
						return new System.Data.SqlTypes.SqlBinary((System.Byte[])row["definition", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["definition"] = DBNull.Value;
				else
					row["definition"] = value.Value; 
 
			} 
		}

	}



	/// <summary>
	/// Wraps a datarow, exposing it's richest features as properties and methods.
	/// </summary>
	public abstract class TagsOrmTemplate : Business
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="dataContext">The DataManager this object should perform it's operations with</param>
		/// <param name="ROW">The underlying row that this object will wrap</param>
		internal TagsOrmTemplate( DataManager dataContext, DataRow ROW) : base(dataContext) 
		{ 
			row = ROW; 
		}


		/// <summary>
		/// Gets and sets the property at the underlying row index.
		/// </summary>
		public object this[int index]
		{
			get
			{
				if ( this.row.IsNull(index) )
					return null;
				else
					return this.row[index];
			}
			set
			{
				if ( value == null )
					this.row[index] = DBNull.Value;
				else
					this.row[index] = value;
			}
		}

		/// <summary>
		/// Gets and sets the property by its name.
		/// </summary>
		/// <remarks>
		/// Do not use the underlying column name if it is different.
		/// </remarks>
		public object this[string property]
		{
			get
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanRead )
					return pi.GetValue(this, null);

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Get" + property,new System.Type[]{});
								
				if ( mi != null )
					return mi.Invoke(this, null);

				return null;
			}
			set
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanWrite )
				{
					pi.SetValue(this, value, null);
					return;
				}

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Set" + property,new System.Type[]{value.GetType()});
								
				if ( mi != null )
					mi.Invoke(this, new object[]{value});
			}
		}		

		
		/// <summary>
		/// Returns true if the underlying DataRow.RowState is marked as DataRowState.Deleted
		/// </summary>
		/// <returns>true if deleted</returns>
		public virtual bool IsDeleted()
		{
			return row.RowState == DataRowState.Deleted;
		}

		/// <summary>
		/// Gets and Sets the id.
		/// </summary>
		/// <value>
		/// The underlying rows id cell
		/// </value>
		public virtual System.String id 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("id") ? null : (System.String) row["id"]; 
				else
					return row.IsNull(row.Table.Columns["id"], DataRowVersion.Original) ? null : (System.String) row["id", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["id"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the GroupsAllowedToSet.
		/// </summary>
		/// <value>
		/// The underlying rows GroupsAllowedToSet cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlInt32 GroupsAllowedToSet 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("GroupsAllowedToSet"))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["GroupsAllowedToSet"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["GroupsAllowedToSet"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["GroupsAllowedToSet", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["GroupsAllowedToSet"] = DBNull.Value;
				else
					row["GroupsAllowedToSet"] = value.Value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the TagName.
		/// </summary>
		/// <value>
		/// The underlying rows TagName cell
		/// </value>
		public virtual System.String TagName 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("TagName") ? null : (System.String) row["TagName"]; 
				else
					return row.IsNull(row.Table.Columns["TagName"], DataRowVersion.Original) ? null : (System.String) row["TagName", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["TagName"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the TagDescription.
		/// </summary>
		/// <value>
		/// The underlying rows TagDescription cell
		/// </value>
		public virtual System.String TagDescription 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("TagDescription") ? null : (System.String) row["TagDescription"]; 
				else
					return row.IsNull(row.Table.Columns["TagDescription"], DataRowVersion.Original) ? null : (System.String) row["TagDescription", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["TagDescription"] = value; 
 
			} 
		}
		
		/// <summary>
		/// Gets and Sets the parent BuildWolfSandboxBiz.Groups.
		/// </summary>
		 
		public virtual BuildWolfSandboxBiz.Groups Groups
		{
			get
			{
				if (row.GetParentRow(base.DataSet.Relations["GroupsAllowedToSetTags"]) != null)
					return new BuildWolfSandboxBiz.Groups( DataContext, row.GetParentRow("GroupsAllowedToSetTags"));
				else
					return null;
			}
			set
			{
				if ( value == null )
				{
					row.SetParentRow(null, base.DataSet.Relations["GroupsAllowedToSetTags"] );
				}
				else
					row.SetParentRow( value.row, base.DataSet.Relations["GroupsAllowedToSetTags"] );			
			}
		}
	

	}



	/// <summary>
	/// Wraps a datarow, exposing it's richest features as properties and methods.
	/// </summary>
	public abstract class UsersOrmTemplate : Business
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <param name="dataContext">The DataManager this object should perform it's operations with</param>
		/// <param name="ROW">The underlying row that this object will wrap</param>
		internal UsersOrmTemplate( DataManager dataContext, DataRow ROW) : base(dataContext) 
		{ 
			row = ROW; 
		}


		/// <summary>
		/// Gets and sets the property at the underlying row index.
		/// </summary>
		public object this[int index]
		{
			get
			{
				if ( this.row.IsNull(index) )
					return null;
				else
					return this.row[index];
			}
			set
			{
				if ( value == null )
					this.row[index] = DBNull.Value;
				else
					this.row[index] = value;
			}
		}

		/// <summary>
		/// Gets and sets the property by its name.
		/// </summary>
		/// <remarks>
		/// Do not use the underlying column name if it is different.
		/// </remarks>
		public object this[string property]
		{
			get
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanRead )
					return pi.GetValue(this, null);

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Get" + property,new System.Type[]{});
								
				if ( mi != null )
					return mi.Invoke(this, null);

				return null;
			}
			set
			{
				System.Reflection.PropertyInfo pi = this.GetType().GetProperty(property);
				
				if ( pi != null && pi.CanWrite )
				{
					pi.SetValue(this, value, null);
					return;
				}

				System.Reflection.MethodInfo mi = this.GetType().GetMethod("Set" + property,new System.Type[]{value.GetType()});
								
				if ( mi != null )
					mi.Invoke(this, new object[]{value});
			}
		}		

		
		/// <summary>
		/// Returns true if the underlying DataRow.RowState is marked as DataRowState.Deleted
		/// </summary>
		/// <returns>true if deleted</returns>
		public virtual bool IsDeleted()
		{
			return row.RowState == DataRowState.Deleted;
		}

		/// <summary>
		/// Gets and Sets the id.
		/// </summary>
		/// <value>
		/// The underlying rows id cell
		/// </value>
		public virtual System.Int32 id 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return (System.Int32) row["id"]; 
				else
					return (System.Int32) row["id", DataRowVersion.Original];
				
				//System.Int32 
			} 
			set
			{ 
				row["id"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the WindowsLoginName.
		/// </summary>
		/// <value>
		/// The underlying rows WindowsLoginName cell
		/// </value>
		public virtual System.String WindowsLoginName 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
					return row.IsNull("WindowsLoginName") ? null : (System.String) row["WindowsLoginName"]; 
				else
					return row.IsNull(row.Table.Columns["WindowsLoginName"], DataRowVersion.Original) ? null : (System.String) row["WindowsLoginName", DataRowVersion.Original]; 

				//System.String 
			} 
			set
			{ 
				row["WindowsLoginName"] = value; 
 
			} 
		}
		/// <summary>
		/// Gets and Sets the GroupID.
		/// </summary>
		/// <value>
		/// The underlying rows GroupID cell
		/// </value>
		public virtual System.Data.SqlTypes.SqlInt32 GroupID 
		{ 
			get
			{ 
				if (row.RowState != DataRowState.Deleted)
				{
					if (row.IsNull("GroupID"))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["GroupID"]);
				}
				else
				{
					if (row.IsNull(row.Table.Columns["GroupID"], DataRowVersion.Original))
						return System.Data.SqlTypes.SqlInt32.Null;
					else
						return new System.Data.SqlTypes.SqlInt32((System.Int32)row["GroupID", DataRowVersion.Original]);
				}
 
			} 
			set
			{ 
				if ( value.IsNull ) 
					row["GroupID"] = DBNull.Value;
				else
					row["GroupID"] = value.Value; 
 
			} 
		}
		
		/// <summary>
		/// Gets and Sets the parent BuildWolfSandboxBiz.Groups.
		/// </summary>
		 
		public virtual BuildWolfSandboxBiz.Groups Groups
		{
			get
			{
				if (row.GetParentRow(base.DataSet.Relations["GroupIDUsers"]) != null)
					return new BuildWolfSandboxBiz.Groups( DataContext, row.GetParentRow("GroupIDUsers"));
				else
					return null;
			}
			set
			{
				if ( value == null )
				{
					row.SetParentRow(null, base.DataSet.Relations["GroupIDUsers"] );
				}
				else
					row.SetParentRow( value.row, base.DataSet.Relations["GroupIDUsers"] );			
			}
		}
	
		private BuildWolfSandboxBiz.BuildsCollection _Buildss = null;
	
		/// <summary>
		/// Refreshes the collection of Buildss from the underlying dataset
		/// </summary>
		internal void refreshBuildss()
		{
			if (_Buildss == null) _Buildss = new BuildWolfSandboxBiz.BuildsCollection();
			
			((IList)_Buildss).Clear();

			DataRow[] cr = row.GetChildRows("CreatedByBuilds");
			foreach( DataRow chld in cr)
			{
				BuildWolfSandboxBiz.Builds obj = new BuildWolfSandboxBiz.Builds(base.DataContext, chld);
				_Buildss.Add( obj );
			}
			
			// add after, so that events wont be fired
			_Buildss.Parent = this;
		}
				
		/// <summary>
		/// Exposes the collection of child BuildWolfSandboxBiz.Buildss.
		/// </summary>
		public virtual BuildWolfSandboxBiz.BuildsCollection Buildss
		{
			get 
			{ 
				if (_Buildss == null) refreshBuildss();

				return _Buildss;
			}
		}


			/// <summary>
			/// Adds a BuildWolfSandboxBiz.Builds to the collection.
			/// </summary>
			public virtual int AddBuilds(BuildWolfSandboxBiz.Builds newBuilds)
			{
				if ( _Buildss == null ) refreshBuildss();

				if ( newBuilds.row.GetParentRow(base.DataSet.Relations["CreatedByBuilds"]) == row )
					return _Buildss.IndexOf( newBuilds );

				newBuilds.row.SetParentRow(row,base.DataSet.Relations["CreatedByBuilds"]);

				int index = _Buildss.Add( newBuilds );

				return index;

			}

			/// <summary>
			/// Creates a new BuildWolfSandboxBiz.Builds, adding it to the collection.
			/// </summary>
			/// <remarks>
			/// CommitAll() must be called to persist this to the database.
			/// </remarks>
			/// <returns>A new Builds object</returns>
			public virtual BuildWolfSandboxBiz.Builds NewBuilds()
			{
				if ( _Buildss == null ) refreshBuildss();

				BuildWolfSandboxBiz.Builds newBuilds = new BuildWolfSandboxBiz.Builds(base.DataContext, base.DataSet.Tables["Builds"].NewRow());
				base.DataSet.Tables["Builds"].Rows.Add(newBuilds.row);
				
				this.AddBuilds(newBuilds);

				return newBuilds;
			}
	
		private BuildWolfSandboxBiz.CommentsCollection _Commentss = null;
	
		/// <summary>
		/// Refreshes the collection of Commentss from the underlying dataset
		/// </summary>
		internal void refreshCommentss()
		{
			if (_Commentss == null) _Commentss = new BuildWolfSandboxBiz.CommentsCollection();
			
			((IList)_Commentss).Clear();

			DataRow[] cr = row.GetChildRows("AuthorUserIDComments");
			foreach( DataRow chld in cr)
			{
				BuildWolfSandboxBiz.Comments obj = new BuildWolfSandboxBiz.Comments(base.DataContext, chld);
				_Commentss.Add( obj );
			}
			
			// add after, so that events wont be fired
			_Commentss.Parent = this;
		}
				
		/// <summary>
		/// Exposes the collection of child BuildWolfSandboxBiz.Commentss.
		/// </summary>
		public virtual BuildWolfSandboxBiz.CommentsCollection Commentss
		{
			get 
			{ 
				if (_Commentss == null) refreshCommentss();

				return _Commentss;
			}
		}


			/// <summary>
			/// Adds a BuildWolfSandboxBiz.Comments to the collection.
			/// </summary>
			public virtual int AddComments(BuildWolfSandboxBiz.Comments newComments)
			{
				if ( _Commentss == null ) refreshCommentss();

				if ( newComments.row.GetParentRow(base.DataSet.Relations["AuthorUserIDComments"]) == row )
					return _Commentss.IndexOf( newComments );

				newComments.row.SetParentRow(row,base.DataSet.Relations["AuthorUserIDComments"]);

				int index = _Commentss.Add( newComments );

				return index;

			}

			/// <summary>
			/// Creates a new BuildWolfSandboxBiz.Comments, adding it to the collection.
			/// </summary>
			/// <remarks>
			/// CommitAll() must be called to persist this to the database.
			/// </remarks>
			/// <returns>A new Comments object</returns>
			public virtual BuildWolfSandboxBiz.Comments NewComments()
			{
				if ( _Commentss == null ) refreshCommentss();

				BuildWolfSandboxBiz.Comments newComments = new BuildWolfSandboxBiz.Comments(base.DataContext, base.DataSet.Tables["Comments"].NewRow());
				base.DataSet.Tables["Comments"].Rows.Add(newComments.row);
				
				this.AddComments(newComments);

				return newComments;
			}
	

	}


}