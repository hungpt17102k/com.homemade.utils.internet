#import <UIKit/UIKit.h>

extern "C" {
    void OpenIOSSettings()
    {
        [[UIApplication sharedApplication] openURL:[NSURL URLWithString:UIApplicationOpenSettingsURLString]];
    }
}
