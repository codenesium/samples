import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AirTransportMapper from './airTransportMapper';
import AirTransportViewModel from './airTransportViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface AirTransportDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AirTransportDetailComponentState {
  model?: AirTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class AirTransportDetailComponent extends React.Component<
  AirTransportDetailComponentProps,
  AirTransportDetailComponentState
> {
  state = {
    model: new AirTransportViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.AirTransports + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.AirTransportClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.AirTransports +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new AirTransportMapper();

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
            <div>
              <h3>Airline</h3>
              <p>{String(this.state.model!.airlineId)}</p>
            </div>
            <div>
              <h3>Flight Number</h3>
              <p>{String(this.state.model!.flightNumber)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Handler</h3>
              <p>
                {String(
                  this.state.model!.handlerIdNavigation &&
                    this.state.model!.handlerIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Land Date</h3>
              <p>{String(this.state.model!.landDate)}</p>
            </div>
            <div>
              <h3>Pipeline Step</h3>
              <p>{String(this.state.model!.pipelineStepId)}</p>
            </div>
            <div>
              <h3>Takeoff Date</h3>
              <p>{String(this.state.model!.takeoffDate)}</p>
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

export const WrappedAirTransportDetailComponent = Form.create({
  name: 'AirTransport Detail',
})(AirTransportDetailComponent);


/*<Codenesium>
    <Hash>bea7c4677f44ff2db3283c6f70ded32c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/