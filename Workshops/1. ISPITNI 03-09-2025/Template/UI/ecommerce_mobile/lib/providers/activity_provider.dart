import 'package:ecommerce_mobile/model/activity.dart';
import 'package:ecommerce_mobile/providers/base_provider.dart';

class ActivityProvider extends BaseProvider<Activity> {
  ActivityProvider() : super("Activity");

  @override
  Activity fromJson(dynamic json) {
    return Activity.fromJson(json);
  }
} 