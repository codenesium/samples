import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ContactTypeMapper from './contactTypeMapper';
import ContactTypeViewModel from './contactTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { BusinessEntityContactTableComponent } from '../shared/businessEntityContactTable';

interface ContactTypeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ContactTypeDetailComponentState {
  model?: ContactTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ContactTypeDetailComponent extends React.Component<
  ContactTypeDetailComponentProps,
  ContactTypeDetailComponentState
> {
  state = {
    model: new ContactTypeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ContactTypes + '/edit/' + this.state.model!.contactTypeID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ContactTypes +
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
          let response = resp.data as Api.ContactTypeClientResponseModel;

          console.log(response);

          let mapper = new ContactTypeMapper();

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
              <h3>ContactTypeID</h3>
              <p>{String(this.state.model!.contactTypeID)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>BusinessEntityContacts</h3>
            <BusinessEntityContactTableComponent
              businessEntityID={this.state.model!.businessEntityID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ContactTypes +
                '/' +
                this.state.model!.contactTypeID +
                '/' +
                ApiRoutes.BusinessEntityContacts
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedContactTypeDetailComponent = Form.create({
  name: 'ContactType Detail',
})(ContactTypeDetailComponent);


/*<Codenesium>
    <Hash>7b0c9af993f99b67127f2a5507757065</Hash>
</Codenesium>*/