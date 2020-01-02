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

        

        // 初始化数据源组合框,将现有数据源添加到下拉框中
        private void InitCmbDS(ComboBox cmb)
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
                    cmb.Items.Clear();
                    cmb.BeginUpdate();
                    for (int i =  0; i < DsCount; i++)
                    {
                        //定义数据源对象
                        cmb.Items.Add(objDss[i].Alias);
                    }
                    cmb.EndUpdate();
                   //cmb.SelectedIndex = 0;
                }
            }
            catch (System.Exception ex)
            {
                Application.ActiveApplication.Output.Output(ex.StackTrace);
            }
        }


         //初始化数据集组合框，在listbox中添加指定数据源的点、线、面、属性表等矢量数据集
        private void InitCmbDt(ComboBox cmb, ListBox ListB)
        {
            try
            {
                //首先获取当前窗体的工作空间对象
                Workspace Wkspace = Application.ActiveApplication.Workspace;
                Datasources objDss = Wkspace.Datasources;

                int DtvCount = 0;
                //获取当前的数据源对象
                string DsName = cmb.Text;
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
                        ListB.Items.Clear();
                        ListB.BeginUpdate();
                        for (int i = 0; i<DtCount; i++)
                        {
                            //定义数据源对象
                            Dataset objDt = objDts[i];
                            if (objDt.Type == DatasetType.Point|| objDt.Type == DatasetType.Line  || objDt.Type == DatasetType.Region    ||
                                objDt.Type == DatasetType.CAD  || objDt.Type == DatasetType.LineM || objDt.Type == DatasetType.LinkTable || 
                                objDt.Type == DatasetType.Network || objDt.Type == DatasetType.Topology || objDt.Type == DatasetType.Model)
                            {
                                string DtName = objDt.Name;
                                ListB.Items.Add(DtName);
                                DtvCount++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        ListB.EndUpdate();
                        if (DtvCount == 0) 
                        {
                            Application.ActiveApplication.Output.Output( "该数据源没有点、线、面、属性表等矢量数据集");
                        }
                    }
                }
                else
                {
                    ListB.Items.Clear();
                }
            }
            catch (System.Exception ex)
            {
                Application.ActiveApplication.Output.Output(ex.StackTrace);
            }
        }


        //将一个ListbBox中的图层转移戴另一个ListBox中，并删除原ListBox中的图层名称
        private void ListBoxCopyTo(ListBox lbAdd, ListBox lbRemove)
        {
            //将数据源中选中的图层添加到右侧
            if (lbRemove.SelectedItems.Count > 0)
            {
                object[] selected = new object[lbRemove.SelectedItems.Count];
                lbRemove.SelectedItems.CopyTo(selected, 0);
                foreach (object a in selected)
                {
                    lbAdd.Items.Add(a);
                    lbRemove.Items.Remove(a);
                }
            }
            else
            {
                MessageBox.Show("未选中数据集！");
            }      
        }


        private void cmbDatasource1_Click(object sender, EventArgs e)
        {
            //当数据源组合框下拉操作时，选择输出数据源
                InitCmbDS(cmbDatasource1);
        }

        private void cmbDatasource_Click(object sender, EventArgs e)
        {
            //当数据源组合框下拉操作时，选择数据源
           InitCmbDS(cmbDatasource);
        }

        private void cmbDatasource_SelectedIndexChanged(object sender, EventArgs e)
        {
            //将选择的数据源包含的图层显示在listbox中
            InitCmbDt(cmbDatasource,lbDataset);
        }


        //添加需要转换的数据集
        private void btnRightMove_Click(object sender, EventArgs e)
        {
            //将数据源中选中的图层添加到右侧
            ListBoxCopyTo(lbInsert, lbDataset); 
        }

        //修改需要转换的数据集
        private void btnLeftMove_Click(object sender, EventArgs e)
        {
            ListBoxCopyTo(lbDataset,lbInsert);   
        }

        //“确定”按钮
        private void btnExportTo_Click(object sender, EventArgs e)
        {
            Workspace Wkspace = Application.ActiveApplication.Workspace;
            Datasources objDss = Wkspace.Datasources;
            int DsCount = objDss.Count;

            //获取输出数据源中所有数据集的名称
            string[] objLayerName = new string[objDss[cmbDatasource1.Text].Datasets.Count];
            int objLayerCount = 0;
            Datasets objDts1 = objDss[cmbDatasource1.Text].Datasets;
            for (int mmm = 0; mmm < objDts1.Count; mmm++)
            {
                objLayerName[objLayerCount] = objDss[cmbDatasource1.Text].Datasets[mmm].Name;
                objLayerCount++;
            }


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

                            //判断输出数据源中是否已经存在需转换数据集对应的“_prop”属性表，若已存在，先删除原来的属性表数据
                            if (Array.IndexOf(objLayerName, layerName + "_prop") != -1)
                            {
                                objDss[cmbDatasource1.Text].Datasets.Delete(layerName + "_prop");
                                Application.ActiveApplication.Output.Output("原“" + layerName + "_prop" + "”图层已删除，等待重新生成！");
                            }
                            
                            
                            DatasetVector dataset1 = objDss[j].Datasets[layerName] as DatasetVector;

                            //获取需要输出的属性字段
                            int countField = 0;
                            for (int p = 0; p < dataset1.FieldCount; p++)
                            {
                                if ((!dataset1.FieldInfos[p].IsSystemField && dataset1.FieldInfos[p].Name != "SmUserID") || dataset1.FieldInfos[p].Name == "SmID")
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
                            for (int x = 0; x < fieldTabCount; x++)
                            {
                                fieldTabName[x] = dataset_tab1.FieldInfos[x].Name;
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
                            outFields_tab[countField - 1] = "Field_SmID";
                            sourceFields_model[countField - 1] = "SmID";

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

    
            
        }
}
