import 'package:ecommerce_mobile/model/user_activity.dart';
import 'package:ecommerce_mobile/providers/base_provider.dart';

class UserActivityProvider extends BaseProvider<UserActivity> {
  UserActivityProvider() : super("UserActivity");

  @override
  UserActivity fromJson(dynamic json) {
    return UserActivity.fromJson(json);
  }
} 