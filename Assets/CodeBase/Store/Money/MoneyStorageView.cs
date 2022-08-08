using TMPro;
using UnityEngine;

namespace CodeBase.Store.Money
{
    public class MoneyStorageView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyAmountField;
        
        private IMoneyStorage _moneyStorage;

        public void Construct(IMoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;

            ShowAmount(_moneyStorage.Amount);
            
            _moneyStorage.AmountChanged += ShowAmount;
        }

        private void OnDestroy()
        {
            _moneyStorage.AmountChanged -= ShowAmount;
        }

        private void ShowAmount(float amount) => 
            _moneyAmountField.text = amount.ToString("F1");
    }
}