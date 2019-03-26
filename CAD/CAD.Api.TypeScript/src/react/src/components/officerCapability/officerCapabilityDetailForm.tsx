import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerCapabilityMapper from './officerCapabilityMapper';
import OfficerCapabilityViewModel from './officerCapabilityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface OfficerCapabilityDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerCapabilityDetailComponentState {
  model?: OfficerCapabilityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class OfficerCapabilityDetailComponent extends React.Component<
  OfficerCapabilityDetailComponentProps,
  OfficerCapabilityDetailComponentState
> {
  state = {
    model: new OfficerCapabilityViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.OfficerCapabilities +
        '/edit/' +
        this.state.model!.capabilityId
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.OfficerCapabilityClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.OfficerCapabilities +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new OfficerCapabilityMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div style={{ marginBottom: '10px' }}>
              <h3>capabilityId</h3>
              <p>
                {String(
                  this.state.model!.capabilityIdNavigation &&
                    this.state.model!.capabilityIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>officerId</h3>
              <p>
                {String(
                  this.state.model!.officerIdNavigation &&
                    this.state.model!.officerIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedOfficerCapabilityDetailComponent = Form.create({
  name: 'OfficerCapability Detail',
})(OfficerCapabilityDetailComponent);


/*<Codenesium>
    <Hash>6b7349e8bf7bde879a7908a085963690</Hash>
</Codenesium>*/