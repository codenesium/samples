import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VenueMapper from './venueMapper';
import VenueViewModel from './venueViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Venues +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.VenueClientResponseModel;

          console.log(response);

          let mapper = new VenueMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
              <p>{String(this.state.model!.adminIdNavigation!.toDisplay())}</p>
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
                {String(this.state.model!.provinceIdNavigation!.toDisplay())}
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
    <Hash>1a1b515b7e129f10d7fe25df6b7a4530</Hash>
</Codenesium>*/