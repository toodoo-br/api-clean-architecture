using br.com.toodoo.sharedkernel.Notifications;

namespace br.com.toodoo.sharedkernel.Interfaces;

public interface INotifier
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}
