import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants, AuthClientRoutes } from '../constants';
import ErrorBoundary from './errorBoundary';
const { Header, Content, Footer, Sider } = Layout;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (
  Component: React.ComponentClass<any> | React.SFC<any>,
  displayName: string
) => {
  class WrapperHeaderComponent extends React.Component<
    WrapperHeaderProps & RouteComponentProps,
    WrapperHeaderState
  > {
    state = { collapsed: true };

    onCollapse = () => {
      this.setState({ ...this.state, collapsed: !this.state.collapsed });
    };
    render() {
      return (
        <Layout style={{ minHeight: '100vh' }}>
          <Sider
            collapsible
            collapsed={this.state.collapsed}
            onCollapse={this.onCollapse}
          >
            <div className="logo" />
            <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
              <Menu.Item
                key="Home"
                onClick={() => {
                  this.setState({ ...this.state, collapsed: true });
                }}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'} />
              </Menu.Item>

              <Menu.Item key="airline">
                <Icon type="pie-chart" />
                <span>Airline</span>
                <Link to={ClientRoutes.Airlines} />
              </Menu.Item>

              <Menu.Item key="airTransport">
                <Icon type="rise" />
                <span>Air Transport</span>
                <Link to={ClientRoutes.AirTransports} />
              </Menu.Item>

              <Menu.Item key="breed">
                <Icon type="bars" />
                <span>Breed</span>
                <Link to={ClientRoutes.Breeds} />
              </Menu.Item>

              <Menu.Item key="country">
                <Icon type="cloud" />
                <span>Country</span>
                <Link to={ClientRoutes.Countries} />
              </Menu.Item>

              <Menu.Item key="countryRequirement">
                <Icon type="code" />
                <span>Country Requirement</span>
                <Link to={ClientRoutes.CountryRequirements} />
              </Menu.Item>

              <Menu.Item key="customer">
                <Icon type="smile" />
                <span>Customer</span>
                <Link to={ClientRoutes.Customers} />
              </Menu.Item>

              <Menu.Item key="customerCommunication">
                <Icon type="laptop" />
                <span>Customer Communication</span>
                <Link to={ClientRoutes.CustomerCommunications} />
              </Menu.Item>

              <Menu.Item key="destination">
                <Icon type="mobile" />
                <span>Destination</span>
                <Link to={ClientRoutes.Destinations} />
              </Menu.Item>

              <Menu.Item key="employee">
                <Icon type="paper-clip" />
                <span>Employee</span>
                <Link to={ClientRoutes.Employees} />
              </Menu.Item>

              <Menu.Item key="handler">
                <Icon type="setting" />
                <span>Handler</span>
                <Link to={ClientRoutes.Handlers} />
              </Menu.Item>

              <Menu.Item key="handlerPipelineStep">
                <Icon type="user" />
                <span>Handler Pipeline Step</span>
                <Link to={ClientRoutes.HandlerPipelineSteps} />
              </Menu.Item>

              <Menu.Item key="otherTransport">
                <Icon type="home" />
                <span>Other Transport</span>
                <Link to={ClientRoutes.OtherTransports} />
              </Menu.Item>

              <Menu.Item key="pet">
                <Icon type="camera" />
                <span>Pet</span>
                <Link to={ClientRoutes.Pets} />
              </Menu.Item>

              <Menu.Item key="pipeline">
                <Icon type="like" />
                <span>Pipeline</span>
                <Link to={ClientRoutes.Pipelines} />
              </Menu.Item>

              <Menu.Item key="pipelineStatus">
                <Icon type="bulb" />
                <span>Pipeline Status</span>
                <Link to={ClientRoutes.PipelineStatus} />
              </Menu.Item>

              <Menu.Item key="pipelineStep">
                <Icon type="tool" />
                <span>Pipeline Step</span>
                <Link to={ClientRoutes.PipelineSteps} />
              </Menu.Item>

              <Menu.Item key="pipelineStepDestination">
                <Icon type="coffee" />
                <span>Pipeline Step Destination</span>
                <Link to={ClientRoutes.PipelineStepDestinations} />
              </Menu.Item>

              <Menu.Item key="pipelineStepNote">
                <Icon type="experiment" />
                <span>Pipeline Step Note</span>
                <Link to={ClientRoutes.PipelineStepNotes} />
              </Menu.Item>

              <Menu.Item key="pipelineStepStatus">
                <Icon type="security-scan" />
                <span>Pipeline Step Status</span>
                <Link to={ClientRoutes.PipelineStepStatus} />
              </Menu.Item>

              <Menu.Item key="pipelineStepStepRequirement">
                <Icon type="thunderbolt" />
                <span>Pipeline Step Step Requirement</span>
                <Link to={ClientRoutes.PipelineStepStepRequirements} />
              </Menu.Item>

              <Menu.Item key="sale">
                <Icon type="gateway" />
                <span>Sale</span>
                <Link to={ClientRoutes.Sales} />
              </Menu.Item>

              <Menu.Item key="species">
                <Icon type="shopping" />
                <span>Species</span>
                <Link to={ClientRoutes.Species} />
              </Menu.Item>

              <Menu.SubMenu
                title={
                  <span>
                    <Icon type="setting" />
                    <span>Settings</span>
                  </span>
                }
              >
                <Menu.Item key="lock">
                  <Icon type="lock" />
                  <span>Change Password</span>
                  <Link to={AuthClientRoutes.ChangePassword} />
                </Menu.Item>
                <Menu.Item key="mail">
                  <Icon type="mail" />
                  <span>Change Email</span>
                  <Link to={AuthClientRoutes.ChangeEmail} />
                </Menu.Item>
                <Menu.Item key="logout">
                  <Icon type="logout" />
                  <span>Logout</span>
                  <Link to={AuthClientRoutes.Logout} />
                </Menu.Item>
              </Menu.SubMenu>
            </Menu>
          </Sider>
          <Layout>
            <Content style={{ margin: '0 16px' }}>
              <h2>{displayName}</h2>
              <div
                style={{ padding: 24, background: '#fff', minHeight: '600px' }}
              >
                <ErrorBoundary>
                  <Component {...this.props} />
                </ErrorBoundary>
              </div>
            </Content>
            <Footer style={{ textAlign: 'center' }}>Footer</Footer>
          </Layout>
        </Layout>
      );
    }
  }
  return WrapperHeaderComponent;
};


/*<Codenesium>
    <Hash>4594e6722fc4c828ac9188f7a1873da6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/