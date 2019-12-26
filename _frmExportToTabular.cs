using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

using SuperMap.Desktop;
using SuperMap.Mapping;
using SuperMap.Data;
using SuperMap.UI;
using SuperMap.Desktop.UI;

namespace SuperMap.Desktop.ExportToTabular
{
    public partial class _frmExportToTabular : Form
    {

        public _frmExportToTabular()
        {
            InitializeComponent();         
        }

        

        // 初始化数据源组合框
        private void InitCmbDS_out()
        {
            try
            {
                //首先获取当前窗体的工作空间对象

                Workspace Wkspace = Application.ActiveApplication.Workspace;
                Datasources objDss = Wkspace.Datasources;
                int DsCount = objDss.Count;

                if (DsCount == 0)
                {
                    return;
                }
                else
                {
                    //添加数据源
                    cmbDatasource1.Items.Clear();
                    cmbDatasource1.BeginUpdate();
                    for (int i =  0; i < DsCount; i++)
                    {
                        //定义数据源对象
                        cmbDatasource1.Items.Add(objDss[i].Alias);
                    }
                    cmbDatasource1.EndUpdate();
                    cmbDatasource1.SelectedIndex = 0;
                }
            }
            catch (System.Exception ex)
            {
               
                Application.ActiveApplication.Output.Output(ex.StackTrace);
            }
        }

        private void InitCmbDS_in()
        {
            try
            {
                //首先获取当前窗体的工作空间对象

                Workspace Wkspace = Application.ActiveApplication.Workspace;
                Datasources objDss = Wkspace.Datasources;
                int DsCount = objDss.Count;

                if (DsCount == 0)
                {
                    return;
                }
                else
                {
                    //添加数据源
                    cmbDatasource.Items.Clear();
                    cmbDatasource.BeginUpdate();
                    for (int i = 0; i < DsCount; i++)
                    {
                        //定义数据源对象
                        cmbDatasource.Items.Add(objDss[i].Alias);
                    }
                    cmbDatasource.EndUpdate();
                    cmbDatasource1.SelectedIndex = 0;
                }
            }
            catch (System.Exception ex)
            {
                Application.ActiveApplication.Output.Output(ex.StackTrace);
            }
        }

        /// 初始化数据集组合框，添加点、线、面、属性表等矢量数据集
        private void InitCmbDt()
        {
            try
            {
                //首先获取当前窗体的工作空间对象
                Workspace Wkspace = Application.ActiveApplication.Workspace;
                Datasources objDss = Wkspace.Datasources;
                
                int DtvCount = 0;
                //获取当前的数据源对象
                string DsName = cmbDatasource.Text;
                if (DsName == "")
                {
                    return;
                }
                Datasource objDs = objDss[DsName];//
                if (objDs != null)
                {
                    //获取当前数据源中的数据集
                    Datasets objDts = objDs.Datasets;
                    int DtCount = objDts.Count;
                    if (DtCount == 0)
                    {
                        return;
                    }
                    else
                    {
                        //添加数据集
                        lbDataset.Items.Clear();
                        lbDataset.BeginUpdate();
                        for (int i = 0; i<DtCount; i++)
                        {
                            //定义数据源对象
                            Dataset objDt = objDts[i];
                            if (objDt.Type == DatasetType.Point || objDt.Type == DatasetType.Line || objDt.Type == DatasetType.Region ||
                                objDt.Type == DatasetType.Tabular || objDt.Type == DatasetType.CAD || objDt.Type == DatasetType.LineM ||
                                objDt.Type == DatasetType.LinkTable || objDt.Type == DatasetType.Network || objDt.Type == DatasetType.Text ||
                                objDt.Type == DatasetType.Topology || objDt.Type == DatasetType.Model)
                            {
                                string DtName = objDt.Name;
                                lbDataset.Items.Add(DtName);
                                DtvCount++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        lbDataset.EndUpdate();
                        if (DtvCount == 0) 
                        {
                            Application.ActiveApplication.Output.Output( "该数据源没有点、线、面、属性表等矢量数据集");
                        }
                    }
                }
                else
                {
                    lbDataset.Items.Clear();
                }
            }
            catch (System.Exception ex)
            {
                Application.ActiveApplication.Output.Output(ex.StackTrace);
            }
        }

        private void cmbDatasource1_Click(object sender, EventArgs e)
        {
            //当数据源组合框下拉操作时，选择输出数据源
            try
            {
                InitCmbDS_out();
            }
            catch (System.Exception ex)
            {
                Application.ActiveApplication.Output.Output(ex.StackTrace);
            }
        }

        
        private void cmbDatasource_Click(object sender, EventArgs e)
        {
            try
            {
                //当数据源组合框下拉操作时，将数据源包含的图层显示在listbox中
                InitCmbDS_in();
                InitCmbDt();
            }
            catch (System.Exception ex)
            {
                Application.ActiveApplication.Output.Output(ex.StackTrace);
            }
        }

        //添加需要转换的数据集
        private void btnRightMove_Click(object sender, EventArgs e)
        {     
            //将数据源中选中的图层添加到右侧
            if (lbDataset.SelectedItems.Count > 0)
            {
                object[] selected = new object[lbDataset.SelectedItems.Count];
                lbDataset.SelectedItems.CopyTo(selected,0);
                foreach (object a in selected)
                { 
                   lbInsert.Items.Add(a); 
                   lbDataset.Items.Remove(a);
                }
            }
            else
            {
                MessageBox.Show("未选中数据集！");    
            }
        }

        //修改需要转换的数据集
        private void btnLeftMove_Click(object sender, EventArgs e)
        {          
            if (lbInsert.SelectedItems.Count > 0)
            {
                object[] selected = new object[lbInsert.SelectedItems.Count];
                lbInsert.SelectedItems.CopyTo(selected, 0);
                foreach (object a in selected)
                {
                    lbInsert.Items.Remove(a); 
                    lbDataset.Items.Add(a);
                }
            }
            else
            {
                MessageBox.Show("未选中数据集！");
            }           
        }

        //“确定”按钮
        private void btnExportTo_Click(object sender, EventArgs e)
        {
            Workspace Wkspace = Application.ActiveApplication.Workspace;
            Datasources objDss = Wkspace.Datasources;
            int DsCount = objDss.Count;

            int layernnum = lbInsert.Items.Count;    //需要另存为为属性表数据的数据集个数
            for (int i = 0; i < layernnum; i++)
            {           
                string layerName = lbInsert.Items[i].ToString();
                for (int j = 0; j < objDss.Count; j++)
                {
                    Datasets objDts = objDss[j].Datasets; 
                    int DtCount = objDts.Count;
                    for (int m=0;m<DtCount;m++)
                    {
                        if(layerName == objDss[j].Datasets[m].Name)
                        {
                            DatasetVector dataset1 = objDss[j].Datasets[layerName] as DatasetVector;

                            //获取需要输出的属性字段
                            int countField = 0;
                            for (int p = 0; p < dataset1.FieldCount; p++)
                            {
                                if ((!dataset1.FieldInfos[p].IsSystemField && dataset1.FieldInfos[p].Name != "SmUserID") || dataset1.FieldInfos[p].Name  == "SmID")
                                {
                                    countField++;
                                }
                            }
                            string[] sourceFields = new string[countField];
                            int sourceFieldNum = 0;
                            for (int q = 0; q < dataset1.FieldCount; q++)
                            {
                                if ((!dataset1.FieldInfos[q].IsSystemField && dataset1.FieldInfos[q].Name != "SmUserID") || dataset1.FieldInfos[q].Name == "SmID")
                                {
                                    sourceFields[sourceFieldNum] = dataset1.FieldInfos[q].Name;
                                    sourceFieldNum++;
                                }
                            }

                            // 创建纯属性数据集
                            string datasetName = dataset1.GetAvailableFieldName(layerName + "_prop");
                            DatasetVectorInfo dataset_tab = new DatasetVectorInfo();
                            dataset_tab.Type = DatasetType.Tabular;
                            dataset_tab.IsFileCache = true;
                            dataset_tab.Name = datasetName;
                            objDss[cmbDatasource1.Text].Datasets.Create(dataset_tab);


                             //向属性数据集中追加字段
                             DatasetVector dataset_tab1 = objDss[cmbDatasource1.Text].Datasets[datasetName] as DatasetVector;
                             dataset_tab1.AppendFields(dataset1, "SmID", "SmID", sourceFields);

                             //设置floor字段
                             SuperMap.Data.FieldInfo fieldFlood = new SuperMap.Data.FieldInfo("floor", FieldType.Text);
                             fieldFlood.Caption = "floor";
                             fieldFlood.MaxLength = 255;

                             //新建Field_SmID字段
                             SuperMap.Data.FieldInfo fieldSmID = new SuperMap.Data.FieldInfo("Field_SmID", FieldType.Int32);
                             fieldSmID.Caption = "Field_SmID";
                                

                             // 添加floor字段和fieldSmID字段
                             FieldInfos fieldDatasetTab = dataset_tab1.FieldInfos;

                             int fieldTabCount = dataset_tab1.FieldCount;
                             string[] fieldTabName = new string[fieldTabCount];
                             for (int x=0;x<fieldTabCount;x++)
                              {
                                  fieldTabName[x]=dataset_tab1.FieldInfos[x].Name;
                              }
                               if (Array.IndexOf(fieldTabName, "floor") == -1)
                              {
                                  fieldDatasetTab.Add(fieldFlood);      
                              }
                              fieldDatasetTab.Add(fieldSmID);
                              fieldFlood.Dispose();

                              //向属性数据中追加原数据集中的记录（将原图层的"SmID"的添加到新图层的 "Field_SmID"字段中）
                              Recordset recordset = dataset1.GetRecordset(false, CursorType.Dynamic);
                              string[] outFields_tab = new string[countField];
                              string[] sourceFields_model = new string[countField];
                              int f = 0;
                              for (int y = 0; y < countField; y++)
                               {
                                 if (sourceFields[y] != "SmID")
                                  {
                                     outFields_tab[f] = sourceFields[y];
                                     sourceFields_model[f] = sourceFields[y];
                                      f++;
                                  }
                               }
                               outFields_tab[countField-1] = "Field_SmID";
                               sourceFields_model[countField-1] = "SmID";

                               if (dataset_tab1.Append(recordset, sourceFields_model, outFields_tab)) 
                                  {
                                      Application.ActiveApplication.Output.Output("“" + datasetName + "”图层添加成功！");
                                  }
                        }
                    }
                }
                
            }
            MessageBox.Show("完成");
            this.Close();
        }

        //“取消”按钮
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void cmbDatasource_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
            
        }
}
