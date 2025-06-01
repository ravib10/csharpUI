
Feature: 1. Validate Presence of all elements

  Background:
    Given I open "chrome" browser
    And I am on the Home Page of test Website

  @test1
  Scenario: Validate all fields,checkboxes, radio buttons, Submit button and hyperlinks are appearing on the page.
    Then Verify following are appearing on the page or not
      | Fields          |
      | Text input          |
      | Password            |
      | Textarea            |
      | Disabled input      |
      | Readonly input      |
      | Dropdown (select)   |
      | Dropdown (datalist) |
      | File input          |
      | Color picker        |
      | Date picker         |
      | Example range       |
    And Verify following radio buttons are appearing on the page or not
     | RadioButtons        |
      | Checked checkbox |
      | Default checkbox |
    And Verify following check box buttons are appearing on the page or not
     | Checkboxes Names          |
      | Checked radio |
      | Default radio |
    # And Verify if "Submit" button is appearing
    # And Verify if "abcravi" link is appearing

    

      @test2
  Scenario: invalValidate all fields,checkboxes, radio buttons, Submit button and hyperlinks are appearing on the page.
    Then Verify following are appearing on the page or not
      | Fields          |
      | Text input          |
      | Password            |
      | Textarea            |
      | Disabled input      |
      | Readonly input      |
      | Dropdown (select)   |
      | Dropdown (datalist) |
      | File input          |
      | Color picker        |
      | Date picker         |
      | Example range       |
    And Verify following radio buttons are appearing on the page or not
     | RadioButtons        |
      | Checked checkbox |
      | Default checkbox |
    And Verify following check box buttons are appearing on the page or not
     | Checkboxes Names          |
      | Checked radio |
      | Default radio |
    # And Verify if "Submit" button is appearing
    # And Verify if "abcravi" link is appearing



     @test3 @Smoke
  Scenario: insdfsdfsdfsdfvalValidate all fields,checkboxes, radio buttons, Submit button and hyperlinks are appearing on the page.
    Then Verify following are appearing on the page or not
      | Fields          |
      | Text input          |
      | Password            |
      | Textarea            |
      | Disabled input      |
      | Readonly input      |
      | Dropdown (select)   |
      | Dropdown (datalist) |
      | File input          |
      | Color picker        |
      | Date picker         |
      | Example range       |
    And Verify following radio buttons are appearing on the page or not
     | RadioButtons        |
      | Checked checkbox |
      | Default checkbox |
    And Verify following check box buttons are appearing on the page or not
     | Checkboxes Names          |
      | Checked radio |
      | Default radio |
    # And Verify if "Submit" button is appearing
    # And Verify if "abcravi" link is appearing