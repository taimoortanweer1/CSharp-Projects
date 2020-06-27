﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.586
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace crg {
    
    
    public partial class CRG_DATABASECacheClientSyncProvider : Microsoft.Synchronization.Data.SqlServerCe.SqlCeClientSyncProvider {
        
        public CRG_DATABASECacheClientSyncProvider() {
            this.ConnectionString = global::crg.Properties.Settings.Default.ClientCRG_DATABASEConnectionString;
        }
        
        public CRG_DATABASECacheClientSyncProvider(string connectionString) {
            this.ConnectionString = connectionString;
        }
    }
    
    public partial class CRG_DATABASECacheSyncAgent : Microsoft.Synchronization.SyncAgent {
        
        private ProductLogSyncTable _productLogSyncTable;
        
        partial void OnInitialized();
        
        public CRG_DATABASECacheSyncAgent() {
            this.InitializeSyncProviders();
            this.InitializeSyncTables();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public ProductLogSyncTable ProductLog {
            get {
                return this._productLogSyncTable;
            }
            set {
                this.Configuration.SyncTables.Remove(this._productLogSyncTable);
                this._productLogSyncTable = value;
                this.Configuration.SyncTables.Add(this._productLogSyncTable);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeSyncProviders() {
            // Create SyncProviders.
            this.RemoteProvider = new CRG_DATABASECacheServerSyncProvider();
            this.LocalProvider = new CRG_DATABASECacheClientSyncProvider();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeSyncTables() {
            // Create SyncTables.
            this._productLogSyncTable = new ProductLogSyncTable();
            this._productLogSyncTable.SyncGroup = new Microsoft.Synchronization.Data.SyncGroup("ProductLogSyncTableSyncGroup");
            this.Configuration.SyncTables.Add(this._productLogSyncTable);
        }
        
        public partial class ProductLogSyncTable : Microsoft.Synchronization.Data.SyncTable {
            
            partial void OnInitialized();
            
            public ProductLogSyncTable() {
                this.InitializeTableOptions();
                this.OnInitialized();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitializeTableOptions() {
                this.TableName = "ProductLog";
                this.CreationOption = Microsoft.Synchronization.Data.TableCreationOption.DropExistingOrCreateNewTable;
            }
        }
    }
}
namespace crg {
    
    
    public partial class ProductLogSyncAdapter : Microsoft.Synchronization.Data.Server.SyncAdapter {
        
        partial void OnInitialized();
        
        public ProductLogSyncAdapter() {
            this.InitializeCommands();
            this.InitializeAdapterProperties();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeCommands() {
            // ProductLogSyncTableInsertCommand command.
            this.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this.InsertCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) INSERT INTO dbo.ProductLog ([Category], [Manufacturer], [Model No], [Acquired Date], [Cost], [Sale], [Quantity], [Owner], [Description], [Comment], [Last Update]) VALUES (@Category, @Manufacturer, @Model_No, @Acquired_Date, @Cost, @Sale, @Quantity, @Owner, @Description, @Comment, @Last_Update) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.ProductLog')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.ProductLog') ";
            this.InsertCommand.CommandType = System.Data.CommandType.Text;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Category", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Manufacturer", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Model_No", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Acquired_Date", System.Data.SqlDbType.Date));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Sale", System.Data.SqlDbType.Money));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.Decimal));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Owner", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comment", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Last_Update", System.Data.SqlDbType.Date));
            System.Data.SqlClient.SqlParameter insertcommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            insertcommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.InsertCommand.Parameters.Add(insertcommand_sync_row_countParameter);
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            // ProductLogSyncTableDeleteCommand command.
            this.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.DeleteCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) DELETE dbo.ProductLog FROM dbo.ProductLog JOIN CHANGETABLE(VERSION dbo.ProductLog, ([Model No]), (@Model_No)) CT  ON CT.[Model No] = dbo.ProductLog.[Model No] WHERE (@sync_force_write = 1 OR CT.SYS_CHANGE_VERSION IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT.SYS_CHANGE_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_binary)) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.ProductLog')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.ProductLog') ";
            this.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Model_No", System.Data.SqlDbType.VarChar));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            System.Data.SqlClient.SqlParameter deletecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            deletecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.DeleteCommand.Parameters.Add(deletecommand_sync_row_countParameter);
            // ProductLogSyncTableUpdateCommand command.
            this.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.UpdateCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) UPDATE dbo.ProductLog SET [Category] = @Category, [Manufacturer] = @Manufacturer, [Acquired Date] = @Acquired_Date, [Cost] = @Cost, [Sale] = @Sale, [Quantity] = @Quantity, [Owner] = @Owner, [Description] = @Description, [Comment] = @Comment, [Last Update] = @Last_Update FROM dbo.ProductLog  JOIN CHANGETABLE(VERSION dbo.ProductLog, ([Model No]), (@Model_No)) CT  ON CT.[Model No] = dbo.ProductLog.[Model No] WHERE (@sync_force_write = 1 OR CT.SYS_CHANGE_VERSION IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT.SYS_CHANGE_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_binary)) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.ProductLog')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.ProductLog') ";
            this.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Category", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Manufacturer", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Acquired_Date", System.Data.SqlDbType.Date));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Sale", System.Data.SqlDbType.Money));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.Decimal));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Owner", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comment", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Last_Update", System.Data.SqlDbType.Date));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Model_No", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            System.Data.SqlClient.SqlParameter updatecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            updatecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.UpdateCommand.Parameters.Add(updatecommand_sync_row_countParameter);
            // ProductLogSyncTableSelectConflictDeletedRowsCommand command.
            this.SelectConflictDeletedRowsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectConflictDeletedRowsCommand.CommandText = "SELECT CT.[Model No], CT.SYS_CHANGE_CONTEXT, CT.SYS_CHANGE_VERSION FROM CHANGETAB" +
                "LE(CHANGES dbo.ProductLog, @sync_last_received_anchor) CT WHERE (CT.[Model No] =" +
                " @Model_No AND CT.SYS_CHANGE_OPERATION = \'D\')";
            this.SelectConflictDeletedRowsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectConflictDeletedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectConflictDeletedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Model_No", System.Data.SqlDbType.VarChar));
            // ProductLogSyncTableSelectConflictUpdatedRowsCommand command.
            this.SelectConflictUpdatedRowsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectConflictUpdatedRowsCommand.CommandText = @"SELECT [Category], [Manufacturer], dbo.ProductLog.[Model No], [Acquired Date], [Cost], [Sale], [Quantity], [Owner], [Description], [Comment], [Last Update], CT.SYS_CHANGE_CONTEXT, CT.SYS_CHANGE_VERSION FROM dbo.ProductLog JOIN CHANGETABLE(VERSION dbo.ProductLog, ([Model No]), (@Model_No)) CT  ON CT.[Model No] = dbo.ProductLog.[Model No]";
            this.SelectConflictUpdatedRowsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectConflictUpdatedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Model_No", System.Data.SqlDbType.VarChar));
            // ProductLogSyncTableSelectIncrementalInsertsCommand command.
            this.SelectIncrementalInsertsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalInsertsCommand.CommandText = @"IF @sync_initialized = 0 SELECT [Category], [Manufacturer], dbo.ProductLog.[Model No], [Acquired Date], [Cost], [Sale], [Quantity], [Owner], [Description], [Comment], [Last Update] FROM dbo.ProductLog LEFT OUTER JOIN CHANGETABLE(CHANGES dbo.ProductLog, @sync_last_received_anchor) CT ON CT.[Model No] = dbo.ProductLog.[Model No] WHERE (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary) ELSE  BEGIN SELECT [Category], [Manufacturer], dbo.ProductLog.[Model No], [Acquired Date], [Cost], [Sale], [Quantity], [Owner], [Description], [Comment], [Last Update] FROM dbo.ProductLog JOIN CHANGETABLE(CHANGES dbo.ProductLog, @sync_last_received_anchor) CT ON CT.[Model No] = dbo.ProductLog.[Model No] WHERE (CT.SYS_CHANGE_OPERATION = 'I' AND CT.SYS_CHANGE_CREATION_VERSION  <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.ProductLog')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.ProductLog')  END ";
            this.SelectIncrementalInsertsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            // ProductLogSyncTableSelectIncrementalDeletesCommand command.
            this.SelectIncrementalDeletesCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalDeletesCommand.CommandText = @"IF @sync_initialized > 0  BEGIN SELECT CT.[Model No] FROM CHANGETABLE(CHANGES dbo.ProductLog, @sync_last_received_anchor) CT WHERE (CT.SYS_CHANGE_OPERATION = 'D' AND CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.ProductLog')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.ProductLog')  END ";
            this.SelectIncrementalDeletesCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            // ProductLogSyncTableSelectIncrementalUpdatesCommand command.
            this.SelectIncrementalUpdatesCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalUpdatesCommand.CommandText = @"IF @sync_initialized > 0  BEGIN SELECT [Category], [Manufacturer], dbo.ProductLog.[Model No], [Acquired Date], [Cost], [Sale], [Quantity], [Owner], [Description], [Comment], [Last Update] FROM dbo.ProductLog JOIN CHANGETABLE(CHANGES dbo.ProductLog, @sync_last_received_anchor) CT ON CT.[Model No] = dbo.ProductLog.[Model No] WHERE (CT.SYS_CHANGE_OPERATION = 'U' AND CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.ProductLog')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.ProductLog')  END ";
            this.SelectIncrementalUpdatesCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeAdapterProperties() {
            this.TableName = "ProductLog";
        }
    }
    
    public partial class CRG_DATABASECacheServerSyncProvider : Microsoft.Synchronization.Data.Server.DbServerSyncProvider {
        
        private ProductLogSyncAdapter _productLogSyncAdapter;
        
        partial void OnInitialized();
        
        public CRG_DATABASECacheServerSyncProvider() {
            string connectionString = global::crg.Properties.Settings.Default.CRG_DATABASEConnectionString;
            this.InitializeConnection(connectionString);
            this.InitializeSyncAdapters();
            this.InitializeNewAnchorCommand();
            this.OnInitialized();
        }
        
        public CRG_DATABASECacheServerSyncProvider(string connectionString) {
            this.InitializeConnection(connectionString);
            this.InitializeSyncAdapters();
            this.InitializeNewAnchorCommand();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public ProductLogSyncAdapter ProductLogSyncAdapter {
            get {
                return this._productLogSyncAdapter;
            }
            set {
                this._productLogSyncAdapter = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeConnection(string connectionString) {
            this.Connection = new System.Data.SqlClient.SqlConnection(connectionString);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeSyncAdapters() {
            // Create SyncAdapters.
            this._productLogSyncAdapter = new ProductLogSyncAdapter();
            this.SyncAdapters.Add(this._productLogSyncAdapter);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeNewAnchorCommand() {
            // selectNewAnchorCmd command.
            this.SelectNewAnchorCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectNewAnchorCommand.CommandText = "Select @sync_new_received_anchor = CHANGE_TRACKING_CURRENT_VERSION()";
            this.SelectNewAnchorCommand.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlParameter selectnewanchorcommand_sync_new_received_anchorParameter = new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt);
            selectnewanchorcommand_sync_new_received_anchorParameter.Direction = System.Data.ParameterDirection.Output;
            this.SelectNewAnchorCommand.Parameters.Add(selectnewanchorcommand_sync_new_received_anchorParameter);
        }
    }
}
