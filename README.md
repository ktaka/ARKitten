# ARKitten
技術評論社の月刊誌Software Designの「ARKitとUnityで作るiPhone ARアプリ集中特講」で開発するサンプルのリポジトリです。

![ARKitten](ARKitten.jpg)

[2018年3月号](http://gihyo.jp/magazine/SD/archive/2018/201803)の記事での完成状態がコミットされています。

2018年2月号での完成状態は[こちら](https://github.com/ktaka/ARKitten/tree/part_2)をご覧ください。

## 2018年3月号
UnityのAsset Storeから[ARKitのプラグイン](http://u3d.as/RTd)をインポートしてからビルドしてください。

### 誌面掲載ソースコードの全文
- [リスト1 CatControlのスクリプト修正](https://github.com/ktaka/ARKitten/blob/part_3_1/Assets/CatControl.cs)
- [リスト2 BallControl](https://github.com/ktaka/ARKitten/blob/part_3_1/Assets/BallControl.cs)
- [リスト3 CatControl.cs](https://github.com/ktaka/ARKitten/blob/part_3/Assets/CatControl.cs)
- [リスト4 BallOperation.cs](https://github.com/ktaka/ARKitten/blob/part_3_2/Assets/BallOperation.cs)
- [リスト5 BallControl](https://github.com/ktaka/ARKitten/blob/part_3/Assets/BallControl.cs)
- [リスト6 BallOperation.cs](https://github.com/ktaka/ARKitten/blob/part_3/Assets/BallOperation.cs)

## Cute Kittenのアセット
このプロジェクトで使用している猫のモデルのアセット（Cute Kitten）は元はUnityのAsset Storeからダウンロード、インポートしていました。
アセットの作者の事情によりAsset Storeからはこのアセットはダウンロードできなくなってしまいましたが、このサンプルプロジェクトに含める許可を頂きました。
作者の[Alexey Kuznetsov](http://leshiy3d.com/)氏に感謝します。

### 利用方法
「完成状態のものを見るだけではつまらない、解説記事の手順に沿って自分で開発したい！」という方は、下記2つの進め方があります。
- [2月号での完成状態](https://github.com/ktaka/ARKitten/tree/part_2)から始める
  - プロジェクトウィンドウのAssetsの下に既にKittenフォルダがあり、3月号の記事の分から自分の手で進められます
- 自分で作ったプロジェクトにアセットのフォルダをコピーする
  - このリポジトリをClone、もしくは[ダウンロード](https://github.com/ktaka/ARKitten/archive/master.zip)する
  - Finder等でARKitten/Assetsのフォルダを開き、Kittenフォルダがあることを確認する
  - KittenフォルダをUnityのプロジェクトウィンドウのAssetsの下にドラッグ＆ドロップする
  - プロジェクトウィンドウのAssetsの下にKittenフォルダが作成され、Asset Storeからインポートした際と同じ状態になります
  - Cute Kittenのインポート部分以外は2月号、3月号の記事の手順の通りに進められます

Special thanks to [Alexey Kuznetsov](http://leshiy3d.com/), the creator of Cute Kitten.

## 日本語で質問出来るフォーラム
主にモバイル端末向けの[VRやARについて日本語で質問できるフォーラム](https://groups.google.com/d/forum/vr_ar_ja)があります。
ご質問等ありましたら、ぜひ[そちら](https://groups.google.com/d/forum/vr_ar_ja)からお願いします。
