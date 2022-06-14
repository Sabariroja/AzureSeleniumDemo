package com.qa.testngdemo;

import org.testng.annotations.BeforeTest;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.annotations.AfterTest;
import org.testng.annotations.BeforeSuite;
import io.github.bonigarcia.wdm.WebDriverManager;
public class BaseTest {
	WebDriver driver;
	@BeforeSuite
	public void setup() {
		WebDriverManager.chromedriver().setup();
		driver = new ChromeDriver();
	}
	@BeforeTest
	public void Google() {
		driver.get("https://www.google.com");
		
	}
	@AfterTest
	public void tearDown() {
		driver.quit();
	}

}
