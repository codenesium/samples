import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerCapabilitiesMapper from './officerCapabilitiesMapper';
import OfficerCapabilitiesViewModel from './officerCapabilitiesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface OfficerCapabilitiesDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerCapabilitiesDetailComponentState {
  model?: OfficerCapabilitiesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class OfficerCapabilitiesDetailComponent extends React.Component<
  OfficerCapabilitiesDetailComponentProps,
  OfficerCapabilitiesDetailComponentState
> {
  state = {
    model: new OfficerCapabilitiesViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.OfficerCapabilities + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.OfficerCapabilitiesClientResponseModel>(
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

        let mapper = new OfficerCapabilitiesMapper();

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
              <h3>Capability</h3>
              <p>
                {String(
                  this.state.model!.capabilityIdNavigation &&
                    this.state.model!.capabilityIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Officer</h3>
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

export const WrappedOfficerCapabilitiesDetailComponent = Form.create({
  name: 'OfficerCapabilities Detail',
})(OfficerCapabilitiesDetailComponent);


/*<Codenesium>
    <Hash>2227a2dbe77fbf88aa8f447e99ba8b58</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/