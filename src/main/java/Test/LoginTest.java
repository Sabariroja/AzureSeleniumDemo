package Test;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.annotations.Test;
import io.github.bonigarcia.wdm.WebDriverManager;
import org.junit.Assert;
public class LoginTest {
@Test
public void LoginTest() {
		WebDriverManager.chromedriver().browserVersion("102.0.5005.63").setup();
WebDriver driver = new ChromeDriver();
// driver.get method used to naviagte to website
		driver.get("http://newtours.demoaut.com/");
// maximize browser size
		driver.manage().window().maximize();
// Assert Website Title with Expected
String title =driver.getTitle();
		Assert.assertEquals("Demoaut.com", title);
// Close Browser
driver.close();
	}
}