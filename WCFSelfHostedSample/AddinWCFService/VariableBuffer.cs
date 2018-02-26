using Scada.AddIn.Contracts.Variable;
using System.Collections.Generic;
using System.Linq;
using Scada.AddIn.Contracts;

namespace AddinWCFService
{
    public class VariableBuffer
    {
        Dictionary<string, VariableData> _variableDictionary = new Dictionary<string, VariableData>();

        public VariableBuffer()
        {
        }

        public VariableBuffer(IEnumerable<IVariable> initialVariables)
        {
            foreach (IVariable elem in initialVariables)
            {
                AddVariable(elem);
            }    
        }

        public void AddVariable(IVariable variable)
        {
            UpdateVariableData(variable);
        }

        public void UpdateVariableData(IVariable variable)
        {
            VariableData varData = null;
            var variableId = variable.Id.ToString();

            if (_variableDictionary.ContainsKey(variableId))
            {
                varData = _variableDictionary[variableId];
            } else
            {
                varData = new VariableData();
                varData.Name = variable.Name;
                var project = variable.Parent.Parent;
                varData.ProjectGuid = project.ProjectId;
                varData.ProjectName = project.Name;
                varData.Identification = variable.Identification;
                varData.VariableId = variable.Id.ToString();
                varData.Type = variable.IecType.ToString();
                varData.State = variable.StateString;
                varData.TimestampSeconds = variable.LastUpdateTime;
                varData.TimestampMilliseconds = variable.LastUpdateTimeMilliSeconds;
                varData.Unit = variable.Unit;
                varData.Value = variable.GetValue(0);
            }

            varData.Value = variable.GetValue(0);
            varData.State = variable.StateString;
            varData.TimestampSeconds = variable.LastUpdateTime;
            varData.TimestampMilliseconds = variable.LastUpdateTimeMilliSeconds;

            _variableDictionary[variableId] = varData;
        }

        public void RemoveVariable(IVariable variable)
        {
            string variableId = variable.Id.ToString();
            if (_variableDictionary.ContainsKey(variableId) == false)
            {
                return;
            }

            _variableDictionary.Remove(variableId);
        }

        public string[] ListAllVariableIDs()
        {
            return _variableDictionary.Keys.ToArray();
        }

        public VariableData GetVariableData(string variableId)
        {
            if (_variableDictionary.ContainsKey(variableId))
            {
                return _variableDictionary[variableId];
            }
            return null;
        }

        public List<VariableData> GetAllVariables()
        {
            return _variableDictionary.Values.ToList();
        }
        
    }

}
