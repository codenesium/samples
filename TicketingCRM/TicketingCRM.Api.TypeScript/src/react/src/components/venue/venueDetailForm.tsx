import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VenueMapper from './venueMapper';
import VenueViewModel from './venueViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface VenueDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VenueDetailComponentState {
  model?: VenueViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VenueDetailComponent extends React.Component<
  VenueDetailComponentProps,
  VenueDetailComponentState
> {
  state = {
    model: new VenueViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Venues + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.VenueClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Venues +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new VenueMapper();

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
              <h3>Address1</h3>
              <p>{String(this.state.model!.address1)}</p>
            </div>
            <div>
              <h3>Address2</h3>
              <p>{String(this.state.model!.address2)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Admin</h3>
              <p>
                {String(
                  this.state.model!.adminIdNavigation &&
                    this.state.model!.adminIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Email</h3>
              <p>{String(this.state.model!.email)}</p>
            </div>
            <div>
              <h3>Facebook</h3>
              <p>{String(this.state.model!.facebook)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Phone</h3>
              <p>{String(this.state.model!.phone)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Province</h3>
              <p>
                {String(
                  this.state.model!.provinceIdNavigation &&
                    this.state.model!.provinceIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Website</h3>
              <p>{String(this.state.model!.website)}</p>
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

export const WrappedVenueDetailComponent = Form.create({
  name: 'Venue Detail',
})(VenueDetailComponent);


/*<Codenesium>
    <Hash>f77667bafff21cf1fdb9fd8a4d7ed83f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/