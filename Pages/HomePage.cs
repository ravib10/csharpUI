using System;
using System.Collections.Generic;
using sampleProject.StepDefinitions;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using System.Reflection.Metadata;
using System.Globalization;
using System.IO;
using OpenQA.Selenium.Support.UI;
using sampleProject.Constants;


namespace sampleProject.Pages;

public class HomePage
{
    [FindsBy(How = How.Name, Using = "my-text")]
    public IWebElement textInput;


    [FindsBy(How = How.Name, Using = "my-password")]
    public IWebElement password;

    [FindsBy(How = How.Name, Using = "my-textarea")]
    public IWebElement textarea;

    [FindsBy(How = How.Name, Using = "my-disabled")]
    public IWebElement disabledInput;

    [FindsBy(How = How.Name, Using = "my-readonly")]
    public IWebElement readonlyInput;

    [FindsBy(How = How.Name, Using = "my-select")]
    public IWebElement dropdownSelect;

    [FindsBy(How = How.Name, Using = "my-datalist")]
    public IWebElement dropdownDatalist;

    [FindsBy(How = How.Name, Using = "my-file")]
    public IWebElement fileInput;

    [FindsBy(How = How.Name, Using = "my-date")]
    public IWebElement datePicker;
    [FindsBy(How = How.Id, Using = "my-check-1")]
    public IWebElement checkedCheckBox;

    [FindsBy(How = How.Id, Using = "my-check-2")]
    public IWebElement unCheckedCheckBox;
    [FindsBy(How = How.Id, Using = "my-radio-1")]
    public IWebElement checkedRadioButton;


    [FindsBy(How = How.Id, Using = "my-radio-2")]
    public IWebElement unCheckedRadioButton;

    [FindsBy(How = How.XPath, Using = "//button[text()='Submit']")]
    public IWebElement submit;

    [FindsBy(How = How.PartialLinkText, Using = "Return to index")]
    public IWebElement returnToIndex;

    [FindsBy(How = How.TagName, Using = "a")]
    public IList<IWebElement> allLinks;

    IWebDriver driver = stepBase.GetDriver();
    bool isElementPresent = false;
    bool isElementInCorrectState = false;

    public HomePage()
    {
        PageFactory.InitElements(stepBase.GetDriver(), this);
    }

    public bool validateFieldsPresence(String fieldName)
    {
        isElementPresent = false;
        if (driver.FindElement(By.XPath("//*[contains(text(),'" + fieldName + "')]")).Displayed)
            isElementPresent = true;
        return isElementPresent;

    }

    public bool validateRadioCheckboxButtonPresence(String name)
    {
        if (driver.FindElement(By.XPath("//label[normalize-space()='Checked radio']")).Displayed)
            isElementPresent = true;
        return isElementPresent;

    }

    public bool validateLinkPresence(String linkName)
    {
        if (driver.FindElement(By.PartialLinkText(linkName)).Displayed)
            isElementPresent = true;
        return isElementPresent;

    }

    public bool validateFieldsState(String fieldName, String fieldState)
    {
        isElementInCorrectState = false;
        if (fieldState.Equals(Constants.Constants.blank, StringComparison.InvariantCultureIgnoreCase))
        {
            if (driver.FindElement(By.XPath("//*[contains(text(),'" + fieldName + "')]/input")).Text.Equals(",StringComparison.InvariantCultureIgnoreCase)"))
            {
                isElementInCorrectState = true;
            }

        }
        else if (fieldState.Equals(Constants.Constants.blankTextArea, StringComparison.InvariantCultureIgnoreCase))
        {
            if (driver.FindElement(By.XPath("//*[contains(text(),'" + fieldName + "')]/textarea")).Text.Equals(",StringComparison.InvariantCultureIgnoreCase)"))
            {
                isElementInCorrectState = true;
            }
        }
        return isElementInCorrectState;
    }

    public bool isEnabled(String fieldName)
    {
        if (fieldName.Equals(Constants.Constants.disabledInput))
        {
            if (!disabledInput.Enabled)
            {
                isElementInCorrectState = true;
            }
        }
        return isElementInCorrectState;
    }

    public bool isReadOnly(String fieldName)
    {
        if (fieldName.Equals(Constants.Constants.readOnlyInput))
        {
            String attribute = readonlyInput.GetAttribute("readonly");
            if (bool.Parse(attribute))
            {
                isElementInCorrectState = true;
            }
        }
        return isElementInCorrectState;
    }

    public bool defaultValue(String fieldName, String value)
    {
        bool correctValue = false;
        if (fieldName.Equals(Constants.Constants.readOnlyInput, StringComparison.OrdinalIgnoreCase))
        {
            String defaultValue = readonlyInput.GetAttribute("value");
            if (defaultValue.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                correctValue = true;
            }
        }
        else if (fieldName.EndsWith(Constants.Constants.disabledInput, StringComparison.OrdinalIgnoreCase))
        {
            String defaultValue = disabledInput.GetAttribute("placeholder");
            if (defaultValue.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                correctValue = true;
            }
        }
        else if (fieldName.Equals(Constants.Constants.drapDownSelect, StringComparison.OrdinalIgnoreCase))
        {
            String defaultValue = dropdownSelect.FindElement(By.XPath("//option[1]")).GetAttribute("selected");
            if (bool.Parse(defaultValue))
            {
                correctValue = true;
            }
        }
        else if (fieldName.Equals(Constants.Constants.dropDownDataList, StringComparison.OrdinalIgnoreCase))
        {
            String defaultValue = dropdownDatalist.GetAttribute("placeholder");
            if (defaultValue.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                correctValue = true;
            }
        }
        return correctValue;
    }

    public bool isSelected(String selectedOptionName)
    {
        bool isSelected = false;
        if (selectedOptionName.Equals("Checked checkbox", StringComparison.OrdinalIgnoreCase))
            isSelected = checkedCheckBox.Selected;
        else if (selectedOptionName.Equals("Default checkbox", StringComparison.OrdinalIgnoreCase))
        {
            if (!unCheckedCheckBox.Selected)
                isSelected = true;
        }
        else if (selectedOptionName.Equals("Checked radio", StringComparison.OrdinalIgnoreCase))
            isSelected = checkedRadioButton.Selected;
        else if (selectedOptionName.Equals("Default radio", StringComparison.OrdinalIgnoreCase))
        {
            if (!unCheckedRadioButton.Selected)
                isSelected = true;
        }

        return isSelected;
    }

    public bool isHeightChangeable(String fieldName)
    {
        bool isHeightChangeable = false;
        if (fieldName.Equals("Textarea", StringComparison.OrdinalIgnoreCase))
        {
            isHeightChangeable = textarea.GetAttribute("style").Contains("height");
        }
        return isHeightChangeable;
    }

    public bool click(String elementName)
    {
        bool elementClicked = false;
        if (elementName.Contains("Submit"))
        {
            submit.Click();
            elementClicked = true;
        }
        else if (elementName.Contains("Return to index"))
        {
            returnToIndex.Click();
            elementClicked = true;
        }

        return elementClicked;

    }

    public bool validateURL(String url)
    {
        bool isPageCorrect = false;
        if (driver.Url.Contains(url))
            isPageCorrect = true;
        return isPageCorrect;
    }

    public bool validateTitle(String title)
    {
        bool isTitleCorrect = false;
        if (driver.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            isTitleCorrect = true;
        return isTitleCorrect;
    }

    public bool linkCount(int linkCount)
    {
        bool count = false;
        if (allLinks.Count == linkCount)
            count = true;
        return count;
    }

    public bool linkValidation()
    {
        bool allLiksClicable = false;
        for (int i = 0; i < allLinks.Count; i++)
        {
            if (allLinks[i].Text.Contains("index.html"))
                continue;
            else if (allLinks[i].Text.Contains("pageWithOnLoad.html"))
            {
                allLinks[i].Click();
                driver.SwitchTo().Alert().Accept();
                driver.Navigate().Back();
            }
            else
            {
                allLinks[i].Click();
                driver.Navigate().Back();
            }
        }
        allLiksClicable = true;
        return allLiksClicable;
    }

    public bool enterValue(String value, String fieldName)
    {
        if (fieldName.Contains(Constants.Constants.textInput))
            textInput.SendKeys(value);
        else if (fieldName.Contains(Constants.Constants.password))
            password.SendKeys(value);
        else if (fieldName.Contains(Constants.Constants.textArea))
            textarea.SendKeys(value);
        return true;
    }

    public bool selectValueFromDropDown(String value, String dropDownName)
    {
        bool valueSelected = false;
        SelectElement s;
        if (dropDownName.Contains(Constants.Constants.drapDownSelect))
        {
            s = new SelectElement(dropdownSelect);
            s.SelectByText(value);
            valueSelected = true;
        }
        else if (dropDownName.Contains(Constants.Constants.dropDownDataList))
        {
            dropdownDatalist.SendKeys(value);
            valueSelected = true;
        }
        return valueSelected;
    }

    public bool uploadSampleFile()
    {
        // String fileSeperator = System.getProperty("file.separator");
        // File file = new File("." + fileSeperator + "Sample.xlsx");
        // fileInput.SendKeys(file.getAbsolutePath());
        // Get the file separator (equivalent to System.getProperty("file.separator"))
        string fileSeparator = Path.DirectorySeparatorChar.ToString();

        // Create the file path (equivalent to new File("." + fileSeperator + "Sample.xlsx"))
        string filePath = "." + fileSeparator + "Sample.xlsx";

        // Get the absolute path (equivalent to file.getAbsolutePath())
        string absoluteFilePath = Path.GetFullPath(filePath);
        fileInput.SendKeys(absoluteFilePath);
        return true;
    }

    public bool dateSelection(int daysAhead)
    {

        // Date format
        string dateFormat = "yyyy-MM-dd";

        // Current date
        DateTime currentDate = DateTime.Now;
        string toDate = currentDate.ToString(dateFormat, CultureInfo.InvariantCulture);

        // Add days (daysAhead can be a positive or negative integer)
        //int daysAhead = 5;  // You can modify this based on your requirement
        DateTime futureDate = currentDate.AddDays(5);
        string fromDate = futureDate.ToString(dateFormat, CultureInfo.InvariantCulture);

        // Split the date and reformat
        string[] dateParts = fromDate.Split('-');
        string formattedDate = $"{dateParts[1]}/{dateParts[2]}/{dateParts[0]}";
        datePicker.SendKeys(formattedDate);
        //datePicker.SendKeys(fromdate.split("-")[1] + "/" + fromdate.split("-")[2] + "/" + fromdate.split("-")[0]);

        return true;
    }
}
