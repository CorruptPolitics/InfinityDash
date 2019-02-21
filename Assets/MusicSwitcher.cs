using UnityEngine;
using UnityEngine.UI;

public class MusicSwitcher : MonoBehaviour
{
    Dropdown MusicDropdown;
    public Text m_Text;

    void Start()
    {
        //Fetch the Dropdown GameObject
        MusicDropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        MusicDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(MusicDropdown);
        });

        //Initialise the Text to say the first value of the Dropdown
        m_Text.text = "First Value : " + MusicDropdown.value;
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
        m_Text.text = "New Value : " + change.value;
    }
}