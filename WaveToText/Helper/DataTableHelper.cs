using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WaveToText.Helper {
    public static class DataTableHelper {
        public static List<T> ToList<T>(DataTable dataTable) {
            List<T> list = null;
            if (dataTable != null && dataTable.Rows.Count > 0) {
                list = new List<T>();

                Type t = typeof(T);

                PropertyInfo[] pinfo = t.GetProperties();

                for (int i = 0; i < dataTable.Rows.Count; i++) {
                    T item;
                    object objInstance = Activator.CreateInstance(t, true);

                    for (int j = 0; j < dataTable.Columns.Count; j++) {
                        string colName = dataTable.Columns[j].ColumnName;

                        for (int k = 0; k < pinfo.Length; k++) {
                            if (colName.Equals(pinfo[k].Name, StringComparison.OrdinalIgnoreCase)) {
                                object defaultvalue = null;
                                object[] proAttributes = pinfo[k].GetCustomAttributes(typeof(DataValueDefaultAttribute), false);
                                if (proAttributes.Length > 0) {
                                    DataValueDefaultAttribute loDefectTrack = (DataValueDefaultAttribute)proAttributes[0];

                                    defaultvalue = loDefectTrack.Value;
                                }

                                pinfo[k].SetValue(objInstance, Map(pinfo[k].PropertyType.ToString(), dataTable.Rows[i][colName].ToString(), defaultvalue), null);
                            }
                        }
                    }
                    item = (T)objInstance;
                    list.Add(item);
                }
            }
            return list;
        }

        private static object Map(string enType, string dbValue, object defaultvalue) {
            switch (enType.ToLower().Split('.')[1]) {
                case "boolean":
                    try {
                        return Convert.ToBoolean(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToBoolean(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "sbyte":
                    try {
                        return Convert.ToSByte(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToSByte(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "int16":
                    try {
                        return Convert.ToInt16(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToInt16(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "int32":
                    try {
                        return Convert.ToInt32(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToInt32(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "int64":
                    try {
                        return Convert.ToInt64(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToInt64(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "uint16":
                    try {
                        return Convert.ToUInt16(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToUInt16(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "uint32":
                    try {
                        return Convert.ToUInt32(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToUInt32(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "uint64":
                    try {
                        return Convert.ToUInt64(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToUInt64(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "char":
                    try {
                        return Convert.ToChar(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToChar(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "string":
                    try {
                        return Convert.ToString(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToString(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "byte":
                    try {
                        return Convert.ToByte(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToByte(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "single":
                    try {
                        return Convert.ToSingle(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToSingle(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "double":
                    try {
                        return Convert.ToDouble(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToDouble(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "decimal":
                    try {
                        return Convert.ToDecimal(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToDecimal(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "datetime":
                    try {
                        return Convert.ToDateTime(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Convert.ToDateTime(defaultvalue);
                        } else { throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值"); }
                    }
                case "guid":
                    try {
                        return Guid.Parse(dbValue);
                    } catch {
                        if (defaultvalue != null) {
                            return Guid.Parse(defaultvalue.ToString());
                        } else {
                            throw new Exception("参数转换错误且未指定默认值，请检查数据类型或使用DataValueDefaultAttribute特性指定默认值");
                        }
                        throw;
                    }
                default:
                    return Convert.ToString(dbValue);
            }
        }

        /// <summary>  
        /// List集合转DataTable  
        /// </summary>  
        /// <typeparam name="T">实体类型</typeparam>  
        /// <param name="list">传入集合</param>  
        /// <param name="isStoreDB">是否存入数据库DateTime字段，date时间范围没事，取出展示不用设置TRUE</param>  
        /// <returns>返回datatable结果</returns>  
        public static DataTable ListToTable<T>(List<T> list, bool isStoreDB = true) {
            Type tp = typeof(T);
            PropertyInfo[] proInfos = tp.GetProperties();
            DataTable dt = new DataTable();
            foreach (var item in proInfos) {
                dt.Columns.Add(item.Name, item.PropertyType); //添加列明及对应类型  
            }
            foreach (var item in list) {
                DataRow dr = dt.NewRow();
                foreach (var proInfo in proInfos) {
                    object obj = proInfo.GetValue(item);
                    if (obj == null) {
                        continue;
                    }
                    //if (obj != null)  
                    // {  
                    if (isStoreDB && proInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01")) {
                        continue;
                    }
                    // dr[proInfo.Name] = proInfo.GetValue(item);  
                    dr[proInfo.Name] = obj;
                    // }  
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>  
        /// table指定行转对象  
        /// </summary>  
        /// <typeparam name="T">实体</typeparam>  
        /// <param name="dt">传入的表格</param>  
        /// <param name="rowindex">table行索引，默认为第一行</param>  
        /// <returns>返回实体对象</returns>  
        public static T TableToEntity<T>(DataTable dt, int rowindex = 0, bool isStoreDB = true) {
            Type type = typeof(T);
            T entity = Activator.CreateInstance<T>(); //创建对象实例  
            if (dt == null) {
                return entity;
            }
            //if (dt != null)  
            //{  
            DataRow row = dt.Rows[rowindex]; //要查询的行索引  
            PropertyInfo[] pArray = type.GetProperties();
            foreach (PropertyInfo p in pArray) {
                if (!dt.Columns.Contains(p.Name) || row[p.Name] == null || row[p.Name] == DBNull.Value) {
                    continue;
                }

                if (isStoreDB && p.PropertyType == typeof(DateTime) && Convert.ToDateTime(row[p.Name]) < Convert.ToDateTime("1753-01-02")) {
                    continue;
                }
                try {
                    var obj = Convert.ChangeType(row[p.Name], p.PropertyType);//类型强转，将table字段类型转为对象字段类型  
                    p.SetValue(entity, obj, null);
                } catch (Exception) {
                    // throw;  
                }
                // p.SetValue(entity, row[p.Name], null);                     
            }
            //  }  
            return entity;
        }  
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DataValueDefaultAttribute : Attribute {
        private object value;

        public DataValueDefaultAttribute(object value) {
            this.value = value;
        }
        public object Value { get { return value; } }

    }
}
